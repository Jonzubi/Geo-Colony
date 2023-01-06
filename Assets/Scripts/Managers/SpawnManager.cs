using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    #region Properties
        
    public List<GameObject> _geoChilds;
    public List<GameObject> _foods;
    [SerializeField] GameObject prefabGeoChild;
    [SerializeField] GameObject prefabFood;

    GameManager _gameManager;
    float lastFoodSpawn = 0;

    public List<GameObject> GeoChildren
    {
        get
        {
            return _geoChilds;
        }
    }

    public List<GameObject> Foods
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

    void Update()
    {
        if (lastFoodSpawn >= _gameManager.GetConfigurationManager().SpawnFoodTime)
        {
            GameObject food = Instantiate(prefabFood, CommonFunctions.GetRandomPositionInCamera(), new Quaternion());
            int maxId = 0;
            if (Foods.Count > 0)
                maxId = Foods.Max(f => f.GetComponent<Food>().Id);

            food.GetComponent<Food>().Id = maxId + 1;
            Foods.Add(food);
            lastFoodSpawn = 0;
        }
        else
            lastFoodSpawn += Time.deltaTime;
    }

    public SpawnManager()
    {
        _geoChilds = new List<GameObject>();
        _foods = new List<GameObject>();
    }

    #endregion

    #region Methods
        
    public void SpawnChild()
    {
        GameObject geoChild = Instantiate(prefabGeoChild, CommonFunctions.GetRandomPositionInCamera(), new Quaternion());
        GeoChildren.Add(geoChild);
    }

    public void DestroyChild(int id)
    {
        GameObject food = Foods.Find(f => f.GetComponent<Food>().Id == id);
        Foods.Remove(food);
        Destroy(food);
    }

    #endregion
}
