using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialDialog : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorialText;
    [SerializeField] private Image catChefAvatar;

    //[SerializeField] private T;

    private float dialogOffsetx = 300.0f;
    private float dialogOffsety = 200.0f;

    public void DisplayText(ref string _tutorialText)
    {
        tutorialText.text = _tutorialText;
    }
    public void SetDialogPosition(ref Vector3 displayPosition)
    {
        this.gameObject.transform.position = displayPosition + new Vector3(dialogOffsetx, dialogOffsety, 0.0f);
    }
}
