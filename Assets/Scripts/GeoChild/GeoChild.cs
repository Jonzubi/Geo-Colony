using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoChild : MonoBehaviour
{
    float _moveSpeed = 30f;
    public string Name
    {
        get; set;
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision");    
    }
}
