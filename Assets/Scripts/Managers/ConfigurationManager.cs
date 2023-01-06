using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    float _spawnFoodTime = 0.1f;

    public float SpawnFoodTime
    {
        get { return _spawnFoodTime; }
        set { _spawnFoodTime = value; }
    }
}
