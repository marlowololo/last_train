using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonPart : MonoBehaviour
{

    public float PartHealth;

    [SerializeField] private GameObject HealthBar;
    [SerializeField] private float MinBarSize;
    [SerializeField] private float MaxBarSize;

    bool isWorkerAround;

    private void Start()
    {
        isWorkerAround = false;
    }

    private void Update()
    {
        if(isWorkerAround)
        {
            PartHealth += 1 * Time.deltaTime;
        }

        HealthBar.transform.localScale = new Vector3(
            Mathf.Lerp(MinBarSize, MaxBarSize, PartHealth/100),
            HealthBar.transform.localScale.y,
            HealthBar.transform.localScale.z
        );
    }

}
