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
        rigidBody = GetComponent<Rigidbody2D>();
        UpdateVelocity();
    }

    private void UpdateVelocity()
    {
        Vector2 force = new Vector2(speed * (float)direction, 0);
        rigidBody.velocity = force;
    }

    public void StartMovement()
    {
        if(tempSpeed != 0)
        {
            speed = tempSpeed;
        }
        tempSpeed = 0;
        UpdateVelocity();
    }

    public void StopMovement()
    {
        tempSpeed = speed;
        speed = 0;
        UpdateVelocity();
    }

  }
