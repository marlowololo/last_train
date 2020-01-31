using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBonesSample : MonoBehaviour
{
    [SerializeField] UnityArmatureComponent ac;
    bool walking = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            string animationPlayed = walking ? "WALKING" : "IDLE";
            ac.animation.FadeIn(animationPlayed, 0.3f);
            walking = !walking;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            string animationPlayed = walking ? "WALKING" : "IDLE";
            ac.animation.Play(animationPlayed);
            walking = !walking;
        }
    }
}
