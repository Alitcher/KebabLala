using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelCollection", menuName = "KebabLala/Level/newCollection")]
public class LevelCollection : ScriptableObject
{
    public LevelGroup[] LevelGroups;
    public LevelGroup LevelReset;
}


[System.Serializable]
public class LevelGroup 
{
    public Level level;
    public Tutorial tutorial;
}