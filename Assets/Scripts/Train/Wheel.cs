using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    
    [SerializeField] private float rotationSpeed;

    private float speedFactor = 1;

    void Update()
    {
        transform.Rotate(0, 0, speedFactor * rotationSpeed * Time.deltaTime);
    }

    public void SetSpeedFactor(float value)
    {
        speedFactor = value;
    }
}
