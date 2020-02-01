using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableWorkerMovement : MonoBehaviour
{
    [Range(0,5)] [SerializeField] float speed=1;
    Rigidbody2D rb;
    private void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetYPosition()
    {

    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector2 currentPosition = transform.position;
            Vector2 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            if(targetPosition.x-currentPosition.x!=0)
            {
                rb.velocity= new Vector2(Mathf.Sign(targetPosition.x-currentPosition.x) * speed,0);
            }
            else
            {
                rb.velocity=Vector2.zero;
            }
            
            
        }    
    }


}
