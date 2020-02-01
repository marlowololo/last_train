using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnWorkerTrigger : MonoBehaviour
{
    [SerializeField] string workerTag;
    [SerializeField] UnityEvent workerEnter,workerStay,workerExit;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(workerTag))
        {
            workerEnter.Invoke();
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        Debug.Log("stay");
        if(other.gameObject.CompareTag(workerTag))
        {
            workerStay.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(workerTag))
        {
            workerExit.Invoke();
        }
    }

}
