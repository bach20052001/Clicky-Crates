using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfiguration",menuName ="Configuration",order = 0)]
public class GameConfig : ScriptableObject
{
    [Header("Easy")]
    public float timeToSpawn_Easy;
    [Header("Normal")]
    public float timeToSpawn_Normal;
    [Header("Hard")]
    public float timeToSpawn_Hard;
}
