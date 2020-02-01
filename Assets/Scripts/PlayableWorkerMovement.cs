using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableWorkerMovement : MonoBehaviour
{
    [Range(0,10)] [SerializeField] float speed=1;
    [Range(0,0.5f)] [SerializeField] float offset;
    Rigidbody2D rb;
    public Vector2 currentPosition;
    public Vector2 targetPosition;
    float yPosition;
    public float direction=1;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity=Vector2.zero;
        yPosition = transform.position.y;
        targetPosition = currentPosition;
    }
    public void SetYPosition()
    {

    }
    private void Update() 
    {
        // if(Input.GetKeyDown(KeyCode.Mouse0))
        // {            
        //     targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     targetPosition = new Vector2(targetPosition.x,yPosition); 
        //     direction = Mathf.Sign(targetPosition.x-currentPosition.x);
        //     rb.velocity=new Vector2(direction*speed,0);

        // }

        currentPosition = transform.position;

        if(direction==1)
        {
           
            if(currentPosition.x>targetPosition.x)
            {
                rb.velocity=Vector2.zero;
            }
                        
        }
        else if(direction==-1)
        {
            if(currentPosition.x<targetPosition.x)
            {
                rb.velocity=Vector2.zero;
            }
         
        }
        
           
    }
    public void MoveTo(Vector2 targetPos)
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition = new Vector2(targetPosition.x,yPosition); 
        direction = Mathf.Sign(targetPosition.x-currentPosition.x);
        rb.velocity=new Vector2(direction*speed,0);
    }




}
