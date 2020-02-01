using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    

    [Range(0,5)] [SerializeField]  float speed;
    [SerializeField] Direction direction;
    [SerializeField]  enum Direction
    {
        left=-1,
        right=1
    }

    float tempSpeed = 0;

    Rigidbody2D rigidBody;
    
    private void Start() 
    {
        rigidBody=GetComponent<Rigidbody2D>();
        Vector2 force = new Vector2(speed*(float)direction,0);        
        rigidBody.velocity=force;
    }

    public void StartMovement()
    {
        speed = tempSpeed;
        tempSpeed = 0;
    }

    public void StopMovement()
    {
        speed = 0;
        tempSpeed = speed;
    }

  }
