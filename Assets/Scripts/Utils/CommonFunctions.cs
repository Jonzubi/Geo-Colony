using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonFunctions
{
    public static Camera mainCamera;
    public static Vector2 GetRandomPositionInCamera()
    {
        float spawnY = Random.Range
            (CommonFunctions.GetCamera().ScreenToWorldPoint(new Vector2(0, 0)).y, CommonFunctions.GetCamera().ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = Random.Range
            (CommonFunctions.GetCamera().ScreenToWorldPoint(new Vector2(0, 0)).x, CommonFunctions.GetCamera().ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

        Vector2 spawnPosition = new Vector2(spawnX, spawnY);
        
        return spawnPosition;
    }

    public static Camera GetCamera()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        return mainCamera;
    }
}
