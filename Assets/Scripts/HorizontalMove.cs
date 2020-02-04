using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    [SerializeField] ParalaxController paralaxController;
    [Range(0,20)] [SerializeField]  float speed;
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
        if(paralaxController==null)
        {
            paralaxController = GameManager.Instance.paralaxController;
        }
        rigidBody = GetComponent<Rigidbody2D>();
        UpdateVelocity();
    }

    public void UpdateVelocity()
    {
        if(paralaxController == null)
        {
            return;
        }
        Vector2 force = new Vector2(paralaxController.speedFactor*speed * (float)direction, 0);
        if(rigidBody != null)
        {
            rigidBody.velocity = force;
        }
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
