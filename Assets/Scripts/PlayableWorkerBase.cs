﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableWorkerBase : MonoBehaviour
{
    public void OnClick()
    {
        GameManager.Instance.selectedWorker.SetSelectedWorker(gameObject);
    }
}
