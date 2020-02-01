using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnMouseClickEvent : MonoBehaviour
{
    [SerializeField] UnityEvent OnMouseClick;

    private void OnMouseDown() 
    {
        OnMouseClick.Invoke();
    }
}
