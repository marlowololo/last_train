using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerHealthRestorer : MonoBehaviour
{
    [SerializeField] string workerTag;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(workerTag))
        {
            other.GetComponent<PlayableWorkerHealth>().StartIncreaseHealth();
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(workerTag))
        {
            other.GetComponent<PlayableWorkerHealth>().StopDecreaseHealth();
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag(workerTag))
        {
            other.GetComponent<PlayableWorkerHealth>().StopIncreaseHealth();
            other.GetComponent<PlayableWorkerHealth>().StartDecreaseHealth();
        }
    }
}
