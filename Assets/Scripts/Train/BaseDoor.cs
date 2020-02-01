using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDoor : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.selectedWorker.MoveTo(gameObject);
    }
}
