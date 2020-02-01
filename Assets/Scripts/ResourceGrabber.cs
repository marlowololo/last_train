using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGrabber : MonoBehaviour
{
    [SerializeField] Collider2D triggerCollider;
    [SerializeField] string resourceTag;
    [SerializeField] string workerTag;
    [SerializeField] ResourceInventoryScriptable resourceInventoryAsset;

    private bool isWorkerArround;

    private void Start()
    {
        isWorkerArround = false;   
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(workerTag))
        {
            
            isWorkerArround = true;
        }

        if(other.gameObject.CompareTag(resourceTag) && isWorkerArround)
        {
            resourceInventoryAsset.resource +=1;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(workerTag))
        {
            isWorkerArround = false;
        }
    }

}
