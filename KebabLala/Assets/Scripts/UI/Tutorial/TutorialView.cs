using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialView : MonoBehaviour
{
    [SerializeField] private Tutorial tutorialDB;

    [SerializeField] private TutorialDialog tutorialDialog;
    [SerializeField] private TutorialMask tutorialMask;

    [SerializeField] private GameObject tutorialCanvas;
    [SerializeField] private RectTransform[] objToTrack;
    [SerializeField] private Transform defalultDialogPosition;


    private Vector3[] objToTrackPosition;
    private int descriptionIndex;


    private void Awake()
    {
        InitObjPosition();
        tutorialCanvas = this.gameObject;
        descriptionIndex = 0;
    }

    private void OnEnable()
    {
        tutorialMask.SetEnablMask(tutorialDB.DisplayMask[descriptionIndex]);
        SetNextTutorial();
    }

    private void InitObjPosition()
    {
        objToTrackPosition = new Vector3[objToTrack.Length];
        for (int i = 0; i < objToTrack.Length; i++)
        {
            objToTrackPosition[i].x = objToTrack[i].position.x;
            objToTrackPosition[i].y = objToTrack[i].position.y;
            objToTrackPosition[i].z = defalultDialogPosition.position.z;
        }
    }

    public void SetNextTutorial()
    {
        if (descriptionIndex >= tutorialDB.Descriptions.Length)
        {
            SetActiveCanvas(false);
        }
        else
        {
            tutorialDialog.DisplayText(ref tutorialDB.Descriptions[descriptionIndex]);
            tutorialDialog.SetDialogPosition(ref objToTrackPosition[descriptionIndex]);
            tutorialMask.SetEnablMask(tutorialDB.DisplayMask[descriptionIndex]);
            tutorialMask.SetMaskPosition(ref objToTrackPosition[descriptionIndex]);
            tutorialMask.SetMaskSize(ref tutorialDB.DialogPosition[descriptionIndex]);
            descriptionIndex++;

        }
    }

    public void SetActiveCanvas(bool isToActive)
    {
        tutorialCanvas.SetActive(isToActive);
    }
}
