using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;

public class PlayableWorkerSoundController : MonoBehaviour
{
    [SerializeField] AudioClip clickSound;
    [SerializeField] AudioClip fixingSound;
    [SerializeField] UnityArmatureComponent armatureComponent;

    [SerializeField] AudioSource audioSource;
    

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying)
        {
            if(armatureComponent.animationName=="fixing")
            {
                audioSource.clip=fixingSound;
                audioSource.Play();
            }
            else
            {
                audioSource.clip=clickSound;
            }

        }
        
    }
}
