using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : Overlay
{
    [SerializeField] private TextKeyPair levelText;

    internal void SetLevelText(string level)
    {
        levelText.SetDescription(ref level);
    }
}
