using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GeoChild> _geoChilds;
    public List<Food> _foods;
    [SerializeField] GameObject prefabGeoChild;
    [SerializeField] GameObject prefabFood;

    public SpawnManager()
    {
        _geoChilds = new List<GeoChild>();
        _foods = new List<Food>();
    }

    public List<GeoChild> GeoChildren
    {
        get
        {
            return _geoChilds;
        }
    }

    public List<Food> Foods
    {
        get
        {
            return _foods;
        }
    }

    public void SpawnChild()
    {
        Instantiate(prefabGeoChild, CommonFunctions.GetRandomPositionInCamera(), new Quaternion());
    }
}
