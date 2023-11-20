using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class KebabData : MonoBehaviour
{
    [HideInInspector]
    public Food kebabData;
    public Food kebabDataScriptable;

    public GameObject[] Mixtures => Ingredients;
    [SerializeField] private GameObject[] Ingredients;

    public void SetActiveIndredients()
    {
        kebabData = Instantiate(kebabDataScriptable);
        StringBuilder idBuilder = new StringBuilder();

        for (int i = 0; i < Ingredients.Length; i++)
        {

            if (System.Enum.TryParse(Ingredients[i].name, out KebabMixtures mixture) &&
                GameSystem.Instance.gameManager.playingLevel.MixtureCollection.Contains(mixture))
            {
                bool isActive = Random.Range(0, 2) == 0;
                kebabData.isMixtureActive[i] = isActive;
                idBuilder.Append(isActive ? "1" : "0");
                Ingredients[i].SetActive(isActive);
            }
            else
            {
                kebabData.isMixtureActive[i] = false;
                idBuilder.Append("0");
                Ingredients[i].SetActive(false);
            }

            kebabData.id = idBuilder.ToString();

        }
    }

    internal bool CheckMatch(GameObject[] kebabDatas)
    {
        bool match = true;
        for (int i = 0; i < Mixtures.Length; i++)
        {
            if (!Mixtures[i].activeSelf)
            {
                continue;
            }
            if (kebabDatas[i].name != Mixtures[i].name)
            {
                print($"{kebabDatas[i].name} and {Mixtures[i].name}");
                match = false;
            }
        }
        this.gameObject.SetActive(false);
        return match;
    }
}
