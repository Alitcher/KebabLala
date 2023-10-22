using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "tutorial-x", menuName = "KebabLala/Tutorial/newTutorialSet")]
public class Tutorial : ScriptableObject
{
    public string id;
    public bool displayChef = true;
    public string[] Descriptions;
    public bool[] DisplayMask;
    public Vector4[] DialogPosition;

    public float left, top, right, bot;
}
