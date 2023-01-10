using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCircle : MonoBehaviour
{
    GameManager _gameManager;

    void Awake() {
        _gameManager = FindObjectOfType<GameManager>();    
    }
    void Update()
    {
        if (!Debug.isDebugBuild)
            return;

        float radius = _gameManager.GetSpawnManager().GeoChildren.Count * _gameManager.GetConfigurationManager().IncreasePerGeoChild;
        Debug.DrawCircle(transform.position, radius, 32, Color.red);
    }
}
