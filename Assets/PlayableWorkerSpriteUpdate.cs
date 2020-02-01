using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableWorkerSpriteUpdate : MonoBehaviour
{
    SpriteRenderer sprite;
    PlayableWorkerMovement movement;

    private void Start() 
    {
        sprite = GetComponent<SpriteRenderer>();    
        movement = GetComponent<PlayableWorkerMovement>();
    }
    // Update is called once per frame
    void Update()
    {
        if(movement.direction==1)
        {
            sprite.flipX=false;
        }
        else if(movement.direction==-1)
        {
            sprite.flipX=true;
        }
    }
}
