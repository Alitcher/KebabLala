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

    [Range(1,4)]
    public int MaxOrder = 1;
    [Range(1, 5)]
    public int MaxCudtomersQueue = 1;

    public float timeSlack;
    public Tutorial tutorialDB;
    public KebabMixtures[] MixtureCollection;
    public Drinks[] DrinkCollection;
    public Shelves[] MixtureShelfCollection;
    public Vector2[] targetMask;

    public int plate1Count;
    public int plate2Count;
}

