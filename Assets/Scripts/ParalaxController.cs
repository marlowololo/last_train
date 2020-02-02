using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    [Range(0,10)] public float speedFactor=1;
    HorizontalMove[] prefabList;

    
    public void StartMovement()
    {
        prefabList = GetComponentsInChildren<HorizontalMove>();
        foreach(var item in prefabList)
        {
            item.StartMovement();
        }
    }

    public void StopMovement()
    {
        prefabList = GetComponentsInChildren<HorizontalMove>();
        foreach(var item in prefabList)
        {
            item.StopMovement();
        }
    }

    public void UpdateSpeedFactor(float newSpeedFactor)
    {
        speedFactor = newSpeedFactor;
        prefabList = GetComponentsInChildren<HorizontalMove>();
        foreach(var item in prefabList)
        {
            item.UpdateVelocity();
        }
    }

}
