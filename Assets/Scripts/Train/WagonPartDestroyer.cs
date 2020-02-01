using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonPartDestroyer : MonoBehaviour
{

    [SerializeField] float DefaultDamage = 25;

    private List<WagonPart> allWagonPart;

    private float currentRandomTimer;
    private float currentTime;

    private float timerRandomMin;
    private float timerRandomMax;

    private void Start()
    {
        currentTime = 0;
        currentRandomTimer = 5;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= currentRandomTimer)
        {
            int damageIndex = Random.Range(0, allWagonPart.Count);
            currentRandomTimer = Random.Range(timerRandomMin, timerRandomMax);

            allWagonPart[damageIndex].PartHealth -= DefaultDamage;

            currentTime = 0;
        }
    }

    public void Init(List<WagonPart> wagonParts, float minRandom, float maxRandom)
    {
        allWagonPart = wagonParts;
        timerRandomMin = minRandom;
        timerRandomMax = maxRandom;
    }
}
