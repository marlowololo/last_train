using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayableWorkerHealth))]
public class PlayableWorkerSickEvent : MonoBehaviour
{
    [Header("Sick Status :")]
    [SerializeField] bool isSick;

    [Header("Settings :")]
    [SerializeField] float sickHealthLevel;

    [SerializeField] UnityEvent sickEvent;
    [SerializeField] UnityEvent notSickEvent;

    PlayableWorkerHealth playableWorkerHealth;

    private void Start() 
    {
        playableWorkerHealth=GetComponent<PlayableWorkerHealth>();    
    }
    private void Update() 
    {
        if(playableWorkerHealth.GetHealth()<sickHealthLevel)
        {
            isSick=true;
            sickEvent.Invoke();           
        }
        else
        {
            isSick=false;
            notSickEvent.Invoke();
        }
    }
}
