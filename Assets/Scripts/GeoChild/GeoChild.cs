using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoChild : MonoBehaviour
{
    public int Id { get; set; }
    float _moveSpeed = 30f;
    public int MitosisOn { get; set; } = 10;
    
    public string Name { get; set; }

    public int FoodEaten { get; set; }

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
            _gameManager.GetSpawnManager().DestroyChild(other.gameObject.GetComponent<Food>().Id);
            FoodEaten++;
            if (FoodEaten == MitosisOn)
            {
                _gameManager.GetSpawnManager().MitosisChild(Id);
                FoodEaten = 0;
            }
        }
    }
}
