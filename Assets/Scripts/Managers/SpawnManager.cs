using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    #region Properties
        
    public List<GeoChild> _geoChilds;
    public List<Food> _foods;
    [SerializeField] GameObject prefabGeoChild;
    [SerializeField] GameObject prefabFood;

    GameManager _gameManager;

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

    #endregion
    
    #region Constructors
        
    void Awake()
    {
        _gameManager = GetComponent<GameManager>();    
    }

    public SpawnManager()
    {
        _geoChilds = new List<GeoChild>();
        _foods = new List<Food>();
    }

    #endregion

    #region Methods
        
    public void SpawnChild()
    {
        Instantiate(prefabGeoChild, CommonFunctions.GetRandomPositionInCamera(), new Quaternion());
    }
    
    #endregion
}
