using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeoChild : MonoBehaviour
{
    [SerializeField] TextMeshPro tmpName;
    public int Id { get; set; }
    float _moveSpeed = 30f;
    float _visionDistance = 7.5f;
    public int MitosisOn { get; set; } = 3;
    
    string _name = "";
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            tmpName.text = _name;
        }
    }

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

    public float GetVisionDistance()
    {
        return _visionDistance;
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
