using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseLadder))]
public class LadderWorkerTeleport : MonoBehaviour
{
    [SerializeField] string workerTag;
    [SerializeField] float roofYPosition;

    BaseLadder baseLadder;

    private void Start() {
        roofYPosition = GetComponent<SpriteRenderer>().bounds.max.y;
        baseLadder = GetComponent<BaseLadder>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(workerTag))
        {
            if(baseLadder.activeWorker==null)
            {
                baseLadder.activeWorker = other.gameObject;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other) {

        if(other.gameObject.CompareTag(workerTag))
        {
            if(baseLadder.activeWorker==other.gameObject&&other.GetComponent<PlayableWorkerMovement>().isIdle)
            {
                other.transform.position= new Vector2(other.transform.position.x,roofYPosition);
                
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(workerTag))
        {
            if(baseLadder.activeWorker==other.gameObject)
            {
                baseLadder.activeWorker=null;
            }
                
        }
    }
}
