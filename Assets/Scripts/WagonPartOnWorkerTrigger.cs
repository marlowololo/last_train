using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonPartOnWorkerTrigger : MonoBehaviour
{

    [SerializeField] WagonPart wagonPart;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(ObjectTagUtil.WorkerTag))
        {
            wagonPart.SetBeingRepaired(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag(ObjectTagUtil.WorkerTag))
        {
            wagonPart.TryRemoveActiveWorker(other.gameObject);
        }
    }
}
