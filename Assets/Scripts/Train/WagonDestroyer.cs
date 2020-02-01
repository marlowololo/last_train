using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonDestroyer : MonoBehaviour
{

    [SerializeField] float DefaultDamage = 25;

    List<Wagon> wagonList;

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
            int damageIndex = Random.Range(0, wagonList.Count);
            currentRandomTimer = Random.Range(timerRandomMin, timerRandomMax);

            wagonList[damageIndex].DamageWagon(DefaultDamage);

            currentTime = 0;
        }
    }

    public void Init(List<Wagon> wagons, float minRandom, float maxRandom)
    {
        wagonList = wagons;
        timerRandomMin = minRandom;
        timerRandomMax = maxRandom;
    }
}
