using DG.Tweening;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class KebabData : MonoBehaviour
{
    [HideInInspector]
    public Container kebabData;
    public Container kebabDataScriptable;

    public GameObject[] CustomerMixtures => Ingredients;
    [SerializeField] private GameObject[] Ingredients;

    [SerializeField] private int[] MixtureSellPricesList;

    public void SetActiveIndredients()
    {
        kebabData = Instantiate(kebabDataScriptable);
        StringBuilder idBuilder = new StringBuilder();
        bool atLeastOneActive = false; // Flag to track if at least one ingredient is active.

        for (int i = 0; i < Ingredients.Length; i++)
        {

            if (System.Enum.TryParse(Ingredients[i].name, out KebabMixtures mixture) &&
                GameSystem.Instance.gameManager.playingLevel.MixtureCollection.Contains(mixture))
            {
                bool isActive = Random.Range(0, 2) == 0;
                kebabData.isMixtureActive[i] = isActive;
                idBuilder.Append(isActive ? "1" : "0");
                Ingredients[i].SetActive(isActive);
                if (isActive)
                {
                    atLeastOneActive = true;
                }
            }
            else
            {
                kebabData.isMixtureActive[i] = false;
                idBuilder.Append("0");
                Ingredients[i].SetActive(false);
            }


        }

        // If no ingredient was set to active, set one ingredient to active randomly.
        if (!atLeastOneActive)
        {
            // Generate a valid random index within the bounds of the Ingredients array.
            int randomIndex = Random.Range(0, Ingredients.Length);

            // Ensure that the randomIndex is within the valid range.
            randomIndex = Mathf.Clamp(randomIndex, 0, Ingredients.Length - 1);

            // Set the randomly selected ingredient to active.
            kebabData.isMixtureActive[randomIndex] = true;

            // Update the corresponding character in the idBuilder to '1'.
            idBuilder[randomIndex] = '1';

            // Set the selected ingredient to active.
            Ingredients[randomIndex].SetActive(true);
        }
        kebabData.id = idBuilder.ToString();
    }

    internal bool CheckMatch(GameObject[] kebabDatas)
    {
        for (int i = 0; i < CustomerMixtures.Length; i++)
        {
            // Check if both elements are active or not active.
            if (kebabDatas[i].activeSelf != CustomerMixtures[i].activeSelf)
            {
                // If one is active and the other is not, this is not a match.
                return false;
            }

            // If both elements are active, check if their names match.
            if (kebabDatas[i].activeSelf && CustomerMixtures[i].activeSelf)
            {
                if (kebabDatas[i].name != CustomerMixtures[i].name)
                {
                    // If the names don't match, it's not a perfect match.
                    return false;
                }
            }
        }

        // Deactivate the game object after checking.
        this.gameObject.SetActive(false);

        // If the loop completes without returning false, it's a match.
        return true;
    }

    internal bool CheckMatch(string id, bool isHanded)
    {
        bool matched = kebabData.id == id;
        if (matched ) 
        {
            DoShakeAnimation();
            if (isHanded) 
            {
                this.gameObject.SetActive(false);

            }
        }

        return matched;
    }

    private void DoShakeAnimation()
    {
        this.transform.DOShakePosition(
            0.5f, // Duration of shake
            new Vector3(5, 5, 0), // Increase strength for more noticeable shakes
            20, // Increase vibrato for more distinct shakes
            90, // Randomness, affects the shake variation
            false, // Snapping
            true // Fade out towards the end
        );


    }
}
