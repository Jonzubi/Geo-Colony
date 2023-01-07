using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour
{
    [SerializeField] Move _move;
    Vector2 center;
    float radius = 0.07f;

    void Awake()
    {
        center = transform.localPosition;    
    }

    void Update()
    {
        Vector2 lookAt = _move.GetTargetFoodPosition() != null ? (Vector2)_move.GetTargetFoodPosition() : (Vector2)_move.GetRandomPointPosition();
        Vector2 eyePosition = center + ((center - lookAt).normalized * -radius);
        transform.localPosition = eyePosition;
        Vector2 newPos = transform.localPosition;
        transform.localPosition = new Vector3(newPos.x, newPos.y, -0.1f);
    }
}
