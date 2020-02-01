using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLadder : MonoBehaviour
{
    public GameObject activeWorker;
    public void OnClick()
    {
        GameManager.Instance.selectedWorker.MoveTo(gameObject);
    }

    public void SetActiveWorker(GameObject g)
    {
        activeWorker=g;
    }

    public void RemoveActiveWorker()
    {
        activeWorker=null;
    }
}
