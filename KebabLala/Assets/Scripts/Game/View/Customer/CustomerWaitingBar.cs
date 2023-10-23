using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerWaitingBar : MonoBehaviour
{
    [SerializeField] private Slider WaitingBar;
    private float waitingTime = 20;
    void Start()
    {
        // Initialize the slider value
        WaitingBar.value = 1f;

    }

    private void StartCountdown()
    {
        WaitingBar.DOValue(0, waitingTime).SetEase(Ease.Linear);
    }

    private void StartCountdown(float _waitingTime)
    {
        WaitingBar.DOValue(0, _waitingTime).SetEase(Ease.Linear);
    }
}
