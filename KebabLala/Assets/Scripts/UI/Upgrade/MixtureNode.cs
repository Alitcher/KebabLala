using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixtureNode : MonoBehaviour
{
    [SerializeField] private Color32[] ActiveColors;
    [SerializeField] private Image[] MixturesImgs;

    [SerializeField] private int Cost;
    [SerializeField] private int CurrectPrice;
    [SerializeField] private int NextPrice;
}
