using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayableWorkerHealth : MonoBehaviour
{
    [Header("Health Monitor")]
    [SerializeField] float health;
    [Header("Settings :")]
    [SerializeField] bool runDecreaseAtStart;
    [Range(0,500)] [SerializeField] float maxHealth;
    [Range(0,500)] [SerializeField] float decreasePerSecond;
    [Range(0,500)] [SerializeField] float increasePerSecond;
    [Range(0,10)] [SerializeField] float timeStep;

    // Start is called before the first frame update
    void Start()
    {
        health =maxHealth;
        if(runDecreaseAtStart)
        {
            StartDecreaseHealth();
        }
        
    }

    IEnumerator DecreaseHealth(float decreasePerSec)
    {
        while(true)
        {
            health-=timeStep*decreasePerSec;
            if(health<0)
            {
                health=0;
            }
            yield return new WaitForSecondsRealtime(timeStep);

        }
    }

    IEnumerator IncreaseHealth(float increasePerSec)
    {
        while(health<maxHealth)
        {
            health+=timeStep*increasePerSec;
            if(health>maxHealth)
            {
                health=maxHealth;
            }
            yield return new WaitForSecondsRealtime(timeStep);
        }

    }

    public void StartDecreaseHealth(float decreasePerSec)
    {
        StartCoroutine(DecreaseHealth(decreasePerSec));
    }
    public void StartDecreaseHealth()
    {
        StartCoroutine(DecreaseHealth(decreasePerSecond));
    }
    public void StopDecreaseHealth()
    {
        StopCoroutine("DecreaseHealth");
    }

    public void StartIncreaseHealth(float increasePerSec)
    {
        StartCoroutine(IncreaseHealth(increasePerSec));
    }
    public void StartIncreaseHealth()
    {
        StartCoroutine(IncreaseHealth(increasePerSecond));
    }
    public void StopIncreaseHealth()
    {
        StopCoroutine("IncreaseHealth");
    }

    public void SetHealth(float healthVal)
    {
        health=healthVal;
    }

    public void ResetHealth()
    {
        health=maxHealth;
    }
    


}
