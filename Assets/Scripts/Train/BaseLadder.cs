using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLadder : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.selectedWorker.MoveTo(gameObject);
    }
}
