using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _gameManager;
    
    public static GameManager GetGameManager()
    {
        if (_gameManager == null)
            _gameManager = new GameManager();

        return _gameManager;
    }
}
