using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    GameManager _gameManager;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();    
    }
}
