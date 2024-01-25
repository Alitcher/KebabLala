using DG.Tweening;
using System.Collections.Generic;
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

    private List<int> activeMixtureIndices = new List<int>();
    public void SetActiveIndredients()
    {
        kebabData = Instantiate(kebabDataScriptable);
        StringBuilder idBuilder = new StringBuilder();
        bool atLeastOneActive = false; // Flag to track if at least one ingredient is active.
        bool isActive = false;

        for (int i = 0; i < Ingredients.Length; i++)
        {

            if (System.Enum.TryParse(Ingredients[i].name, out KebabMixtures mixture) &&
                GameSystem.Instance.gameManager.playingLevel.MixtureCollection.Contains(mixture))
            {
                activeMixtureIndices.Add(i);
                isActive = Random.Range(0, 2) == 0;
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
            int randomIndex = Random.Range(0, activeMixtureIndices.Count);
            int mixtureIndex = activeMixtureIndices[randomIndex];
            Ingredients[mixtureIndex].SetActive(true);
            kebabData.isMixtureActive[mixtureIndex] = true;

            idBuilder[mixtureIndex] = '1';
        }
        kebabData.id = idBuilder.ToString();
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
