using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoChild : MonoBehaviour
{
    public int Id
    {
        get; set;
    }
    float _moveSpeed = 30f;
    
    public string Name
    {
        get; set;
    }

    public int FoodEaten
    {
        get; set;
    }

    GameManager _gameManager;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();    
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            FoodEaten++;
            _gameManager.GetSpawnManager().DestroyChild(other.gameObject.GetComponent<Food>().Id);
        }
    }
}
