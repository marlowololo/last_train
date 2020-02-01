using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    [SerializeField] private LevelSettingScriptable levelSetting;
    [SerializeField] private Train train;
    [SerializeField] private ResourceSpawner resourceSpawner;
    [SerializeField] private WagonDestroyer wagonDestroyer;
    [SerializeField] private WagonPartDestroyer wagonPartDestroyer;
    [SerializeField] private SelectedWorker selectedWorker;

    int currentResourceSpawnIndex;
    float currentTime;
    bool traveling;

    private void Awake()
    {
        _instance = GetComponent<GameManager>();
    }

    void Start()
    {
        currentResourceSpawnIndex = 0;
        currentTime = 0;
        traveling = false;
        train.InitWagon();
        StartLevel(0);
    }
    
    public void StartLevel(int levelIndex)
    {
        traveling = true;
        StartCoroutine(StartLevelTimer(levelIndex));
        wagonPartDestroyer.Init(
            train.GetAllWagonPart(), 
            levelSetting.LevelSettingDatas[levelIndex].DamageTimerRandomMin, 
            levelSetting.LevelSettingDatas[levelIndex].DamageTimerRandomMax
        );
        wagonDestroyer.Init(
            train.GetAllWagon(),
            levelSetting.LevelSettingDatas[levelIndex].DamageTimerRandomMin,
            levelSetting.LevelSettingDatas[levelIndex].DamageTimerRandomMax
        );
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
