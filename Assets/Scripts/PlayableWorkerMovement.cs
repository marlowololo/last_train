using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableWorkerMovement : MonoBehaviour
{
    [Range(0,10)] [SerializeField] float speed=1;
    [Range(0,0.5f)] [SerializeField] float offset;
    [SerializeField] string ladderTag;
    [SerializeField] string doorTag;
    Rigidbody2D rb;
    public Vector2 currentPosition;
    public Vector2 targetPosition;
    float yPosition;
    public float direction=1;
    float directionY=1;
    bool isOnLadder=false;

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
                rb.velocity=new Vector2(0,rb.velocity.y);
            }
                        
        }
        else if(direction==-1)
        {
            if(currentPosition.x<targetPosition.x)
            {
                rb.velocity=new Vector2(0,rb.velocity.y);
            }
         
        }

        if(directionY==1)
        {
           
            if(currentPosition.y>targetPosition.y)
            {
                rb.velocity=new Vector2(rb.velocity.x,0);
            }
                        
        }
        else if(directionY==-1)
        {
            if(currentPosition.y<targetPosition.y)
            {
                rb.velocity=new Vector2(rb.velocity.x,0);
            }
         
        }
        
           
    }
    public void MoveTo(Vector2 targetPos)
    {
        targetPosition = targetPos;
        targetPosition = new Vector2(targetPosition.x,yPosition); 
        direction = Mathf.Sign(targetPosition.x-currentPosition.x);
        rb.velocity=new Vector2(direction*speed,0);
    }

    // public void MoveTo(GameObject targetPosObj)
    // {
    //     if(isOnLadder==false)
    //     {
    //         if(targetPosObj.CompareTag(doorTag))
    //         {
    //             targetPosition = targetPosObj.transform.position;
    //             targetPosition = new Vector2(targetPosition.x,yPosition); 
    //             direction = Mathf.Sign(targetPosition.x-currentPosition.x);
    //             rb.velocity=new Vector2(direction*speed,0);
    //         }

    //         if(targetPosObj.CompareTag(ladderTag))
    //         {
    //             targetPosition = targetPosObj.transform.position;
    //             targetPosition = new Vector2(targetPosition.x,yPosition); 
    //             direction = Mathf.Sign(targetPosition.x-currentPosition.x);
    //             rb.velocity=new Vector2(direction*speed,0);
    //             StartCoroutine(MoveUpLadder(targetPos));             
    //         }
    //     }
    //     else
    //     {
    //         targetPosition = targetPos;
    //         //targetPosition = new Vector2(xPosition,targetPos.y); 
    //         directionY = Mathf.Sign(targetPosition.y-currentPosition.y);
    //         rb.velocity=new Vector2(0,directionY*speed);
    //     }       
    // }

    public void MoveToLadder(Vector2 targetPos)
    {
        
        targetPosition = targetPos;
        targetPosition = new Vector2(targetPosition.x,yPosition); 
        direction = Mathf.Sign(targetPosition.x-currentPosition.x);
        rb.velocity=new Vector2(direction*speed,0);
        StartCoroutine(MoveUpLadder(targetPos));
        
        
    }
    
    IEnumerator MoveUpLadder(Vector2 targetPos)
    {        
        yield return new WaitWhile(()=>rb.velocity.x!=0);
        targetPosition = targetPos;
        //targetPosition = new Vector2(xPosition,targetPos.y); 
        directionY = Mathf.Sign(targetPosition.y-currentPosition.y);
        rb.velocity=new Vector2(0,directionY*speed);

    }



    




}
