using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioClip clip3;
    [SerializeField] AudioClip clip4;
    [SerializeField] AudioClip pausedClip;
    [SerializeField] AudioClip stationClip;
    [SerializeField] GameObject station;
    bool stationIsActive;
    AudioClip lastClip;

    int current=1;
    private void Start() 
    {
        lastClip = clip1;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        if(!(current == GameManager.Instance.currentPhase))
        {
            if(GameManager.Instance.currentPhase==1)
            {
                current =  GameManager.Instance.currentPhase;
                audioSource.clip=clip1;
                lastClip=audioSource.clip;
                audioSource.Play();
            }
            else if(GameManager.Instance.currentPhase==2)
            {
                current =  GameManager.Instance.currentPhase;
                audioSource.clip=clip2;
                lastClip=audioSource.clip;
                audioSource.Play();
            }
            else if(GameManager.Instance.currentPhase==3)
            {
                current =  GameManager.Instance.currentPhase;
                audioSource.clip=clip3;
                lastClip=audioSource.clip;
                audioSource.Play();
            }
            else if(GameManager.Instance.currentPhase==4)
            {
                current =  GameManager.Instance.currentPhase;
                audioSource.clip=clip4;
                lastClip=audioSource.clip;
                audioSource.Play();
            }
            
            
        }
     
        
        if(station.gameObject.activeInHierarchy==true)
        {
            if(audioSource.clip!=stationClip)
            {
                audioSource.clip=stationClip;
                audioSource.Play();
            }
        }
        else
        {
            if(audioSource.clip==stationClip)
            {
                audioSource.clip=lastClip;
                audioSource.Play();
            } 

        }

    }
}
