using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWorker : MonoBehaviour
{
    [SerializeField] GameObject selectedWorker;

    public void SetSelectedWorker(GameObject worker)
    {
        selectedWorker=worker;
    }

    public void WorkerMove(Vector2 targetPos)
    {
        selectedWorker.GetComponent<PlayableWorkerMovement>().MoveTo(targetPos);
    }

    public void MoveTo(GameObject targetObject)
    {
        selectedWorker.GetComponent<PlayableWorkerMovement>().MoveTo(targetObject.transform.position);
    }

}
