using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelSettingScriptable : ScriptableObject
{
    public List<LevelSettingData> LevelSettingDatas;
    
    [Serializable]
    public class LevelSettingData
    {
        public float LevelTime;
        public List<float> StartSpawnTime;
        public float ResourceSpawnTime;
        public float DamageTimerRandomMin;
        public float DamageTimerRandomMax;
    }
}
