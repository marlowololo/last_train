using DragonBones;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableWorkerMovement : MonoBehaviour
{
    [Header("Dragon Bone")]
    [SerializeField] UnityArmatureComponent armatureComponent;

    [Header("Other")]
    [Range(0,10)] [SerializeField] float speed=1;
    [Range(0,0.5f)] [SerializeField] float offset;
    [SerializeField] string ladderTag;
    [SerializeField] string doorTag;
    Rigidbody2D rb;
    public Vector2 currentPosition;
    public Vector2 targetPosition;
    float yPosition;
    public float yRoofPosition;
    public float direction=1;
    float directionY=1;
    bool isOnLadder=false;
    public bool isIdle = true;
    bool isOnRoof=false;

    private PlayableWorkerSickEvent sickEvent;

    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity=Vector2.zero;
        yPosition = transform.position.y;
        targetPosition = currentPosition;
        sickEvent = GetComponent<PlayableWorkerSickEvent>();

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
                if(!isIdle)
                {
                    isIdle = true;
                    armatureComponent.animation.FadeIn("Idle", 0.25f);
                }
                rb.velocity=new Vector2(0,rb.velocity.y);
            }

        }
        else if(direction==-1)
        {
            if(currentPosition.x<targetPosition.x)
            {
                if(!isIdle)
                {
                    isIdle = true;
                    armatureComponent.animation.FadeIn("Idle", 0.25f);
                }
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

        if(rb.velocity.x!=0)
        {
            transform.position=new Vector2(transform.position.x,yPosition);
        }
        
           
    }
    public void MoveTo(Vector2 targetPos)
    {
        armatureComponent.animation.FadeIn("Run", 0.25f);
        targetPosition = targetPos;
        targetPosition = new Vector2(targetPosition.x,yPosition); 
        direction = Mathf.Sign(targetPosition.x-currentPosition.x);
        armatureComponent.armature.flipX = direction == 1 ? true : false;
        rb.velocity=new Vector2(direction*speed * (sickEvent.isSick ? 0.3f : 1f) ,0);
        isIdle = false;
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
