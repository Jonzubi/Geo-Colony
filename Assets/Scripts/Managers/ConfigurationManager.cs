using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigurationManager : MonoBehaviour
{
    float _spawnFoodTime = 5;
    const int INCREASE_PER_GEOCHILD = 1;

    public float SpawnFoodTime
    {
        get { return _spawnFoodTime; }
        set { _spawnFoodTime = value; }
    }

    public int IncreasePerGeoChild
    {
        get {return INCREASE_PER_GEOCHILD; }
    }
}
