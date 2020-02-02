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

    int current=1;
    private void Start() 
    {
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
                audioSource.Play();
            }
            else if(GameManager.Instance.currentPhase==2)
            {
                current =  GameManager.Instance.currentPhase;
                audioSource.clip=clip2;
                audioSource.Play();
            }
            else if(GameManager.Instance.currentPhase==3)
            {
                current =  GameManager.Instance.currentPhase;
                audioSource.clip=clip3;
                audioSource.Play();
            }
            else if(GameManager.Instance.currentPhase==4)
            {
                current =  GameManager.Instance.currentPhase;
                audioSource.clip=clip4;
                audioSource.Play();
            }
        }
     



    }
}
