using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeoChild : MonoBehaviour
{
    float _moveSpeed = 3;
    public string Name
    {
        get; set;
    }

    public float GetMoveSpeed()
    {
        return _moveSpeed;
    }
}
