﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverWorkerHighlight : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color initColor;
    private void Start() 
    {
        //Physics.queriesHitTriggers=true;
        if(GetComponent<Collider2D>()==null)
        {
            Debug.LogWarning("Collider2D needed");
        }
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        initColor = spriteRenderer.material.color; 
    }

    private void OnMouseOver() 
    {
        spriteRenderer.material.SetColor("_Color", Color.blue);        
    }

    private void OnMouseExit() 
    {
        spriteRenderer.material.SetColor("_Color", initColor); 
    }
}