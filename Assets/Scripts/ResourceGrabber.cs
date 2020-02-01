using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGrabber : MonoBehaviour
{
    [SerializeField] Collider2D triggerCollider;
    [SerializeField] string resourceTag;
    [SerializeField] ResourceInventoryScriptable resourceInventoryAsset;
    [SerializeField] BaseDoor baseDoor;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(resourceTag))
        {
            baseDoor.CollectResource();
            //resourceInventoryAsset.resource +=1;
            Destroy(other.gameObject);
        }
    }

}
