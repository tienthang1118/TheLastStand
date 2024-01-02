using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public EnemiesSetup[] enemies;
}

[System.Serializable]
public class EnemiesSetup
{
    public GameObject prefab;
    public int count;
}