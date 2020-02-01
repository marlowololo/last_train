using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonPart : MonoBehaviour
{

    public float PartHealth;

    [SerializeField] private GameObject HealthBar;
    [SerializeField] private float MinBarSize;
    [SerializeField] private float MaxBarSize;

    [SerializeField] ResourceInventoryScriptable resourceInventoryAsset;

    private bool isBeingRepaired;

    private void Start()
    {
        isBeingRepaired = false;
    }

    private void Update()
    {
        if(isBeingRepaired)
        {
            PartHealth += 15 * Time.deltaTime;
            resourceInventoryAsset.resource -= 1 * Time.deltaTime;
        }

        HealthBar.transform.localScale = new Vector3(
            Mathf.Lerp(MinBarSize, MaxBarSize, PartHealth/100),
            HealthBar.transform.localScale.y,
            HealthBar.transform.localScale.z
        );
    }

    public void SetBeingRepaired(bool value)
    {
        isBeingRepaired = value;
    }



}
