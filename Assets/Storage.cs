using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.selectedWorker.MoveTo(gameObject);
    }
}
