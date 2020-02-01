using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public LevelSettingScriptable levelSetting;
    public Train train;
    public ResourceSpawner resourceSpawner;
    public WagonPartDestroyer wagonPartDestroyer;
    public SelectedWorker selectedWorker;
    public ParalaxController paralaxController;
    public ResourceInventoryScriptable resourceInventory;
    public GameplayUIManager gameplayUIManager;

    private int currentLevelIndex;
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
        resourceInventory.resource = 0;
        train.InitWagon();
        currentLevelIndex = 0;
        StartLevel(currentLevelIndex);
    }
    
    public void StartLevel(int levelIndex)
    {
        currentTime = 0;
        currentResourceSpawnIndex = 0;
        traveling = true;
        paralaxController.StartMovement();
        StartCoroutine(StartLevelTimer(levelIndex));
        wagonPartDestroyer.Init(
            train.GetAllWagonPart(), 
            levelSetting.LevelSettingDatas[levelIndex].DamageTimerRandomMin, 
            levelSetting.LevelSettingDatas[levelIndex].DamageTimerRandomMax
        );
        wagonPartDestroyer.StartTimer();
    }

    public void StartNextLevel()
    {
        currentLevelIndex++;
        StartLevel(currentLevelIndex);
    }

    private IEnumerator StartLevelTimer(int levelIndex)
    {
        float levelTime = levelSetting.LevelSettingDatas[levelIndex].LevelTime;
        List<float> spawnStartTime = levelSetting.LevelSettingDatas[levelIndex].StartSpawnTime;
        while(traveling)
        {
            Debug.Log("traveling");
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
                paralaxController.StopMovement();
                gameplayUIManager.ShowLevelPanel();
                wagonPartDestroyer.StopTimer();
                Debug.Log("LEVEL FINISHED");
                traveling = false;
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
