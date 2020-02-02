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

    [SerializeField] SpriteRenderer targetSprite;
    [SerializeField] Sprite[] spriteList;
    [SerializeField] AudioClip[] clip;

    public float PartDamage = 0f;

    private bool isBeingRepaired;
    private const float MAX_HEALTH = 100f;

    private UnityArmatureComponent currentActiveWorker;

    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        isBeingRepaired = false;
        audioSource = GetComponentInParent<AudioSource>();
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
                    if(!audioSource.isPlaying)
                    {
                        audioSource.clip=clip[2];
                        audioSource.Play();
                    }
                    
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

        if(PartHealth >= 90)
        {
            if(targetSprite.sprite != spriteList[0])
            {
                targetSprite.sprite = spriteList[0];
            }
        }
        else if(PartHealth >= 50)
        {
            if(targetSprite.sprite != spriteList[1])
            {
                targetSprite.sprite = spriteList[1];
                if(audioSource.clip!=clip[0])
                    {
                        audioSource.clip=clip[0];
                        audioSource.Play();
                    }
            }
        }
        else
        {
            if(targetSprite.sprite != spriteList[2])
            {
                targetSprite.sprite = spriteList[2];
                if(audioSource.clip!=clip[1])
                {
                    audioSource.clip=clip[1];
                    audioSource.Play();
                }
            }
        }

            HealthBar.transform.localScale = new Vector3(
            Mathf.Lerp(MinBarSize, MaxBarSize, PartHealth/MAX_HEALTH),
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

    public void RepairPart()
    {
        PartHealth = MAX_HEALTH;
    }

}
