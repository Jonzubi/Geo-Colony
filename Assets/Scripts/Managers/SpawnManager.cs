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
            GameObject food = Instantiate(prefabFood, CommonFunctions.GetRandomPositionInGameRange(), new Quaternion());
            food.GetComponent<Food>().Id = GetNextFoodId();
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
        
    public GameObject SpawnChild(Vector2? position = null)
    {
        Vector2 auxPos = position != null ? (Vector2)position : CommonFunctions.GetRandomPositionInGameRange();
        GameObject geoChildgo = Instantiate(prefabGeoChild, auxPos, new Quaternion());
        GeoChild geoChild = geoChildgo.GetComponent<GeoChild>();
        geoChild.Id = GetNextGeoChildId();
        geoChild.Name = $"#{geoChild.Id}";
        GeoChildren.Add(geoChildgo);
        return geoChildgo;
    }

    public void DestroyChild(int id)
    {
        GameObject food = Foods.Find(f => f.GetComponent<Food>().Id == id);
        Foods.Remove(food);
        Destroy(food);
    }

    public void MitosisChild(int id)
    {
        GameObject geoChild = GeoChildren.Find(g => g.GetComponent<GeoChild>().Id == id);
        StartCoroutine(MitosisEffect(geoChild));
    }

    int GetNextFoodId()
    {
        int maxId = 0;
        if (Foods.Count > 0)
            maxId = Foods.Max(f => f.GetComponent<Food>().Id);
        return maxId + 1;
    }

    int GetNextGeoChildId()
    {
        int maxId = 0;
        if (GeoChildren.Count > 0)
            maxId = GeoChildren.Max(f => f.GetComponent<GeoChild>().Id);
        return maxId + 1;
    }

    #endregion

    #region Corroutines
    IEnumerator MitosisEffect(GameObject geoChild)
    {
        float transition = 0.5f;
        LeanTween.scale(geoChild, new Vector3(0.1f, 0.1f, 0.1f), transition);
        yield return new WaitForSeconds(transition);
        LeanTween.scale(geoChild, new Vector3(1, 1, 1), transition);
        yield return new WaitForSeconds(transition);
        Vector2 auxPos = geoChild.transform.position;
        auxPos.x = auxPos.x - 0.2f;
        GameObject newChild = SpawnChild(auxPos);
    }
    #endregion
}
