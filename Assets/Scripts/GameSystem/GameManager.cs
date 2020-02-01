using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private LevelSettingScriptable levelSetting;
    [SerializeField] private Train train;
    [SerializeField] private ResourceSpawner resourceSpawner;

    int currentResourceSpawnIndex;
    float currentTime;
    bool traveling;

    void Start()
    {
        currentResourceSpawnIndex = 0;
        currentTime = 0;
        traveling = false;
        StartLevel(0);
        train.InitWagon();
    }
    
    public void StartLevel(int levelIndex)
    {
        traveling = true;
        StartCoroutine(StartLevelTimer(levelIndex));
    }

    private IEnumerator StartLevelTimer(int levelIndex)
    {
        float levelTime = levelSetting.LevelSettingDatas[levelIndex].LevelTime;
        List<float> spawnStartTime = levelSetting.LevelSettingDatas[levelIndex].StartSpawnTime;
        while(traveling)
        {
            yield return new WaitForSeconds(1);
            currentTime++;
            Debug.Log("Current time :" + currentTime);

            if(currentResourceSpawnIndex < spawnStartTime.Count)
            {
                if(currentTime >= spawnStartTime[currentResourceSpawnIndex])
                {
                    StartCoroutine(StartResourceSpawn(levelSetting.LevelSettingDatas[levelIndex].ResourceSpawnTime));
                    currentResourceSpawnIndex++;
                }
            }

            if(currentTime >= levelTime)
            {
                traveling = false;
                Debug.Log("LEVEL FINISHED");
            }
        }
    }

    private IEnumerator StartResourceSpawn(float duration)
    {
        resourceSpawner.StartSpawn();
        yield return new WaitForSeconds(duration);
        resourceSpawner.StopSpawn();
    }

}
