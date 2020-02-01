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

    IEnumerator decreaseHealthInstance;
    IEnumerator increaseHealthInstance;

    // Start is called before the first frame update
    void Start()
    {
        health =maxHealth;
        if(runDecreaseAtStart)
        {
            StartDecreaseHealth();
        }
        
    }

    IEnumerator DecreaseHealth()
    {
        while(true)
        {
            health-=timeStep*decreasePerSecond;
            if(health<0)
            {
                health=0;
            }
            yield return new WaitForSecondsRealtime(timeStep);

        }
    }

    IEnumerator IncreaseHealth()
    {
        while(health<maxHealth)
        {
            health+=timeStep*increasePerSecond;
            if(health>maxHealth)
            {
                health=maxHealth;
            }
            yield return new WaitForSecondsRealtime(timeStep);
        }

    }

  
    public void StartDecreaseHealth()
    {
        decreaseHealthInstance= DecreaseHealth();
        StartCoroutine(decreaseHealthInstance);
    }
    public void StopDecreaseHealth()
    {
        StopCoroutine(decreaseHealthInstance);
    }

    public void StartIncreaseHealth()
    {
        increaseHealthInstance=IncreaseHealth();
        StartCoroutine(increaseHealthInstance);
    }
    public void StopIncreaseHealth()
    {
        StopCoroutine(increaseHealthInstance);
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
