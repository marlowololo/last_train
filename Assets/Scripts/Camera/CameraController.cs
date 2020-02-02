using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float ZoomSpeed;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float MaxZoomIn = 1;
    [SerializeField] private float MaxZoomOut = 1;
    [SerializeField] private float ZoomInY = 1;
    [SerializeField] private float ZoomOutY = 1;

    private bool isHolding;
    private Vector3 mouseInitialPosition;
    private Vector3 cameraInitialPosition;
    private Vector3 cameraMoveVector;

    private Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        cameraMoveVector = Vector3.zero;
        mouseInitialPosition = Vector3.zero;
        isHolding = false;
        MainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        if(Input.GetMouseButtonDown(0))
        {
            mouseInitialPosition.Set(Input.mousePosition.x, 0, 0);
            cameraInitialPosition = MainCamera.transform.position;
        }

        isHolding = Input.GetMouseButton(0);
        if(isHolding)
        {
            cameraMoveVector.Set(Input.mousePosition.x, 0, 0);
            Vector3 movementOffset = mouseInitialPosition - cameraMoveVector;
            MainCamera.transform.position = cameraInitialPosition + (movementOffset * MoveSpeed);
        }

        //Zoom
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        float zoomResult = MainCamera.orthographicSize + (ZoomSpeed * scrollValue * Time.deltaTime);
        zoomResult = Mathf.Clamp(zoomResult, MaxZoomIn, MaxZoomOut);
        MainCamera.orthographicSize = zoomResult;

    }
}
