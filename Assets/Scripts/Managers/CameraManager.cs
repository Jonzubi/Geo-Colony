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
    Transform _cameraTransform;
    CinemachineComponentBase _componentBase;

    bool isDragging = false;
    Vector3 startDragging;
    void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _cameraTransform = _cinemachineVirtualCamera.transform;    
    }

    void Update()
    {
        ManageZoom();
        ManageMovement();
    }

    void ManageZoom()
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

    void ManageMovement()
    {
        if (!isDragging && Input.GetMouseButtonDown(0))
        {
            startDragging = Input.mousePosition;
            isDragging = true;
            return;
        }      

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
            return;
        }

        if (isDragging)
        {
            Vector3 actualPosition = Input.mousePosition;
            Vector3 direction = -(actualPosition - startDragging).normalized;
            Debug.Log(direction);
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, _cameraTransform.position + direction * moveScale, Time.deltaTime);
        }
    }
}
