using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWorker : MonoBehaviour
{
    [SerializeField] GameObject selectedWorker;
    [SerializeField] GameObject selectedMarkerPrefab;
    GameObject selectedMarker;

    Vector3 markerDefaultOffset = new Vector3(0, 22f, 0);

    private void Start()
    {
        selectedMarker = Instantiate(selectedMarkerPrefab);
    }

    public void SetSelectedWorker(GameObject worker)
    {
        selectedWorker=worker;
        selectedMarker.transform.SetParent(worker.transform);
        selectedMarker.transform.localPosition = markerDefaultOffset;
    }

    public void MoveTo(GameObject targetObject)
    {
        selectedWorker.GetComponent<PlayableWorkerMovement>().MoveTo(targetObject.transform.position);
    }

    public void MoveToLadder(GameObject targetObject)
    {
        selectedWorker.GetComponent<PlayableWorkerMovement>().MoveToLadder(targetObject.transform.position);
    }

    public void PlayAnimation(string animationName, float easeTime = 0.25f)
    {
        UnityArmatureComponent uac = selectedWorker.GetComponentInChildren<UnityArmatureComponent>();
        if(uac.animation.lastAnimationName != animationName) {
            uac.animation.FadeIn(animationName, easeTime);
        }
    }

}
