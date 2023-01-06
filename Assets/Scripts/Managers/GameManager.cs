using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManager;
    SpawnManager _spawnManager;
    ConfigurationManager _configurationManager;

    void Awake()
    {
        _spawnManager = GetComponent<SpawnManager>();
        _configurationManager = GetComponent<ConfigurationManager>();
        _gameManager = this;    
    }

    void Start()
    {
        if (_spawnManager.GeoChildren.Count == 0)
            _spawnManager.SpawnChild();    
    }
    
    public static GameManager GetGameManager()
    {
        return _gameManager;
    }

    public SpawnManager GetSpawnManager()
    {
        return _spawnManager;
    }

    public ConfigurationManager GetConfigurationManager()
    {
        return _configurationManager;
    }
}
