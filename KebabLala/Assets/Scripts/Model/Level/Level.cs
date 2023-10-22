using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "level-x", menuName = "KebabLala/Level/newLevel")]
public class Level : ScriptableObject
{
    public string id;
    public int moneyGoal;
    public int customerGoal;
    public int timeLimited = 999;
    public int foodWasteLimited = 999;

    public Tutorial tutorialDB;

    public Vector2[] targetMask;
}
