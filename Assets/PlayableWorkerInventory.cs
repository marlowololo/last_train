using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableWorkerInventory : MonoBehaviour
{
    [Header("Status :")]
    [SerializeField] bool isFull;
    [SerializeField] bool isEmpty;
    [SerializeField] int itemCount;
    [Header("Settings :")]
    [SerializeField] int maxItemCount;

    private void Update() 
    {
        if(itemCount>=maxItemCount)
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
        if(itemCount+n > maxItemCount)
        {
            Debug.Log("inventory is already full");
        }
        else
        {
            itemCount+=n;
        }
    }
    public void Remove(int n=1)
    {
        if(itemCount-n < 0)
        {
            Debug.Log("inventory is already zero");
        }
        else
        {
            itemCount-=n;
        }        
    }

    public void RemoveAll()
    {
        itemCount=0;
    }

    public int Count()
    {
        return itemCount;
    }

}
