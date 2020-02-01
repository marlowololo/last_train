using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public LevelSettingScriptable LevelSetting;
    public Train Train;

    void Start()
    {
        StartLevel(0);
        Train.InitWagon();
    }
    
    public void StartLevel(int levelIndex)
    {
        StartCoroutine(StartLevelTimer(levelIndex));
    }

    private IEnumerator StartLevelTimer(int levelIndex)
    {
        yield return new WaitForSeconds(LevelSetting.LevelSettingDatas[levelIndex].LevelTime);
        Debug.Log("Level Finished");
    }


}
