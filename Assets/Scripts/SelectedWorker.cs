using DragonBones;
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
