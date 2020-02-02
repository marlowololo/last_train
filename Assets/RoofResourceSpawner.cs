using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofResourceSpawner : MonoBehaviour
{
    [SerializeField] GameObject resourcePrefab;
    [SerializeField] bool runAtStart=false;
    [Range(-20,20)] [SerializeField] float xPosition=0;
    [Range(-20,20)] [SerializeField] float yPosition=0;    
    [Range(0,20)] [SerializeField] float timeInterval=1;

    [Header("Setting for random values. Random.Range(value,value+deviation). 0 = not using random")]
    [Tooltip("Output value =  Random.Range(value,value+deviation)\n0 = not using random")] 
    [Range(0,10)] [SerializeField] float randomXPositionDeviation=0;

    [Tooltip("Output value =  Random.Range(value,value+deviation)\n0 = not using random")]   
    [Range(0,10)] [SerializeField] float randomYPositionDeviation=0;

    [Tooltip("Output value =  Random.Range(value,value+deviation)\n0 = not using random")]      
    [Range(0,10)] [SerializeField] float randomTimeIntervalDeviation=0;
    
    float boundary;
    private void Start() 
    {
        boundary = GetComponent<SpriteRenderer>().bounds.max.x;
        if(runAtStart)
        {
            StartCoroutine(Spawn()); 
        }        
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            float newXPosition = Random.Range(xPosition,xPosition+randomXPositionDeviation);
            float newYPosition = Random.Range(yPosition,yPosition+randomYPositionDeviation);
            float newTimeInterval = Random.Range(timeInterval,timeInterval+randomTimeIntervalDeviation);
            Vector2 spawnPosition = new Vector2(Random.Range(-boundary,boundary),transform.position.y);
            //transform.position = new Vector2(newXPosition,newYPosition);
            Instantiate(resourcePrefab,spawnPosition,Quaternion.identity, this.transform);
            yield return new WaitForSecondsRealtime(newTimeInterval);
        }
    }

    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }
}
