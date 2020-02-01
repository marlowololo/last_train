using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonPartRepair : MonoBehaviour
{

    [SerializeField] private WagonPart wagonPart;

    public void OnClick()
    {
        wagonPart.SetActiveWorker(GameManager.Instance.selectedWorker.GetSelectedWorkerUAC());
        GameManager.Instance.selectedWorker.MoveTo(gameObject);
    }
}
