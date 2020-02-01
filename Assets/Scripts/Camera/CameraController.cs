using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private float ZoomSpeed;
    [SerializeField] private float MoveSpeed;

    private bool isHolding;
    private Vector3 mouseInitialPosition;
    private Vector3 cameraInitialPosition;

    private Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        isHolding = false;
        MainCamera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        if(Input.GetMouseButtonDown(0))
        {
            mouseInitialPosition = Input.mousePosition;
            cameraInitialPosition = MainCamera.transform.position;
        }

        isHolding = Input.GetMouseButton(0);
        if(isHolding)
        {
            Vector3 movementOffset = mouseInitialPosition - Input.mousePosition;
            MainCamera.transform.position = cameraInitialPosition + (movementOffset * MoveSpeed);
        }

        //Zoom
        float scrollValue = Input.GetAxis("Mouse ScrollWheel");
        MainCamera.orthographicSize += ZoomSpeed * scrollValue * Time.deltaTime;
    }
}
