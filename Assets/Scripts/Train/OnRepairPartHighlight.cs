using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRepairPartHighlight : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        //Physics.queriesHitTriggers=true;
        if(GetComponent<Collider2D>() == null)
        {
            Debug.LogWarning("Collider2D needed");
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.material.color;
        color.a = 0;
        spriteRenderer.material.SetColor("_Color", color);
    }

    private void OnMouseOver()
    {
        Color color = spriteRenderer.material.color;
        color.a = 1;
        spriteRenderer.material.SetColor("_Color", color);
    }

    private void OnMouseExit()
    {
        Color color = spriteRenderer.material.color;
        color.a = 0;
        spriteRenderer.material.SetColor("_Color", color);
    }

}
