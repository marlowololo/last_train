using DragonBones;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDoor : MonoBehaviour
{

    [SerializeField] ResourceGrabber resourceGrabber;
    private UnityArmatureComponent currentWorker;

    public void OnClick()
    {
        currentWorker = GameManager.Instance.selectedWorker.GetSelectedWorkerUAC();
        GameManager.Instance.selectedWorker.MoveTo(gameObject);
    }

    public void TriggerAnimation()
    {
        currentWorker.animation.FadeIn("ForageUp1",0.25f);
    }
}
