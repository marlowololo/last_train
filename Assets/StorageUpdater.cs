using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StorageUpdater : MonoBehaviour
{
    [Header("Status :")]
    [SerializeField] bool isFull;
    [SerializeField] bool isEmpty;
    [SerializeField] int itemCount;

    [Header("Settings :")]
    [SerializeField] int maxItemCount;
    [SerializeField] ResourceInventoryScriptable storageAsset;
    [SerializeField] string workerTag;
 

    private void Update() 
    {
        //if(itemCount>=maxItemCount)
        if(storageAsset.resource >= maxItemCount)
        {
            isFull=true;
        }
        else if(itemCount<=0)
        {
            isEmpty=true;
        }
        else
        {
            isFull=false;
            isEmpty=false;
        }
    }
    public void Add(int n=1)
    {
        storageAsset.resource += n;
        //itemCount+=n;
        //if(itemCount>maxItemCount)
        //{
        //    itemCount=maxItemCount;
        //}

    }
    public void Remove(int n=1)
    {
        storageAsset.resource -= n;
        if(storageAsset.resource < 0)
        {
            storageAsset.resource = 0;
        }
        //itemCount -=n;
        //if(itemCount<0)
        //{
        //    itemCount=0;
        //}   
    }

    public void RemoveAll()
    {
        storageAsset.resource = 0;
    }

    public int Count()
    {
        return (int)storageAsset.resource;
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(workerTag))
        {
            Add(other.GetComponent<PlayableWorkerInventory>().Count());
            other.GetComponent<PlayableWorkerInventory>().RemoveAll();
        }
    }

}
