using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManager;
    public static SpawnManager _spawnManager;
    
    public static GameManager GetGameManager()
    {
        if (_gameManager == null)
        {
            _gameManager = new GameManager();
            _spawnManager = new SpawnManager();
        }

        return _gameManager;
    }
}
