using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
{
    float screenSizeX;
    float spriteSizeX;
    bool isHaveClone=false;
    GameObject clone;

    private void Start() 
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        screenSizeX = height * cam.aspect;
        spriteSizeX = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update() 
    {
        if(!isHaveClone)
        {
            if(transform.position.x+0.5*spriteSizeX<=Camera.main.transform.position.x+0.5*screenSizeX)
            {
                isHaveClone=true;
                clone = Instantiate(gameObject,transform.position+new Vector3(spriteSizeX,0,0),Quaternion.identity);
                clone.name = "c";
            }
        }
        
        if(transform.position.x+0.5*spriteSizeX<=-0.5*screenSizeX)
        {            
            Destroy(gameObject);
        }
        

    }
}

