#nullable enable

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float randomIdleMoveSeconds = 1;
    GameManager _gameManager;
    GeoChild _geoChild;
    GameObject? targetFood;
    Vector2 randomPoint;
    Rigidbody2D _rigidBody;
    float pickedRandomPointTime = 0;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _geoChild = GetComponent<GeoChild>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        targetFood = GetClosestFood();
    }

    void Update()
    {
        if (targetFood == null)
            targetFood = GetClosestFood();
        
        // Still can't find food
        if (targetFood == null)
        {
            // Random movement
            if (randomPoint == null)
                randomPoint = CommonFunctions.GetRandomPositionInGameRange();
            else
            {
                // Check last time point election
                if (pickedRandomPointTime >= randomIdleMoveSeconds)
                {
                    // Pick new point
                    randomPoint = CommonFunctions.GetRandomPositionInGameRange();
                    pickedRandomPointTime = 0;
                }
                else
                    pickedRandomPointTime += Time.deltaTime;
            }

            MoveToTarget(randomPoint);
        }
        else
            MoveToTarget(targetFood.transform.position);
    }

    GameObject? GetClosestFood()
    {
        List<GameObject> foods = _gameManager.GetSpawnManager().Foods;
        float minDist = Mathf.Infinity;
        GameObject? closestFood = null;
        foreach (var food in foods)
        {
            float dist = Vector2.Distance(food.transform.position, transform.position);
            if (minDist > dist && _geoChild.GetVisionDistance() > dist)
            {
                closestFood = food;
                minDist = dist;
            }
        }
        return closestFood;
    }

    void MoveToTarget(Vector2 target)
    {
        float step = _geoChild.GetMoveSpeed() * Time.deltaTime;
        _rigidBody.MovePosition(Vector2.MoveTowards(transform.position, target, step));
    }

    public Vector2? GetTargetFoodPosition()
    {
        return targetFood?.transform.position;
    }

    public Vector2? GetRandomPointPosition()
    {
        return randomPoint;
    }
}
