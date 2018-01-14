using System;
using UnityEngine;

[Serializable]
public class BalloonAndChanse
{
    [Range (0,1)]
    public float ChanseToSpawn;
    public GameObject[] BalloonPrefabs;
}

