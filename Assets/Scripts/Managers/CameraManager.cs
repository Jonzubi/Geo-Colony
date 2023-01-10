using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _cinemachineVirtualCamera;
    [SerializeField] float zoomScale = 1f;
    [SerializeField] float moveScale = 1f;
    GameManager _gameManager;

    CinemachineComponentBase _componentBase;

    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();    
    }

    void Update()
    {
        float mouseWheel = Input.mouseScrollDelta.y;
        if (mouseWheel != 0)
        {
            float oldSize = _cinemachineVirtualCamera.m_Lens.OrthographicSize;
            float newSize = oldSize - Input.mouseScrollDelta.y * zoomScale;

            if (newSize < 5)
                newSize = 5;            
            _cinemachineVirtualCamera.m_Lens.OrthographicSize = Mathf.SmoothStep(oldSize, newSize, 1f);
        }
    }
}
