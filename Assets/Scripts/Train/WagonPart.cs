using DragonBones;
using System;
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
    private const float MAX_HEALTH = 100f;

    private UnityArmatureComponent currentActiveWorker;

    private void Start()
    {
        isBeingRepaired = false;
    }

    private void Update()
    {
        if(isBeingRepaired && currentActiveWorker != null)
        {
            if(resourceInventoryAsset.resource > 0 && PartHealth < MAX_HEALTH)
            {
                if(currentActiveWorker.animation.lastAnimationName != "Fixing")
                {
                    currentActiveWorker.animation.FadeIn("Fixing", 0.25f);
                }
                PartHealth += 15 * Time.deltaTime;
                resourceInventoryAsset.resource -= 1 * Time.deltaTime;
            }
            else
            {
                if(currentActiveWorker.animation.lastAnimationName != "Idle")
                {
                    currentActiveWorker.animation.FadeIn("Idle", 0.25f);
                }
            }
        }

        HealthBar.transform.localScale = new Vector3(
            Mathf.Lerp(MinBarSize, MaxBarSize, PartHealth/100),
            HealthBar.transform.localScale.y,
            HealthBar.transform.localScale.z
        );
    }

    public void TryRemoveActiveWorker(GameObject other)
    {
        if(other.GetComponentInChildren<UnityArmatureComponent>() == currentActiveWorker)
        {
            currentActiveWorker = null;
            SetBeingRepaired(false);
        }
    }

    public void SetBeingRepaired(bool value)
    {
        isBeingRepaired = value;
    }

    public void SetActiveWorker(UnityArmatureComponent unityArmature)
    {
        currentActiveWorker = unityArmature;
    }

}
