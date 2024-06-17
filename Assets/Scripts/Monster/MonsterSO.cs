using System;
using System.Collections.Generic;
using UnityEngine;


public enum StatEnum
{
    Atk,
    Def,
    Hp,
    Speed,
    AttackDictance,
    AttackDelay
}

[System.Serializable]
[CreateAssetMenu(fileName = "NewMonster", menuName = "Monster")]
public class MonsterSO : ScriptableObject
{
    [Header("Info")]
    public Sprite monsterIcon;
    public string monsterName;

    [Header("Shop")]
    public int gold;
    public int exp;

    [Header("Stats")]
    public MonsterStats[] monsterStats;
    private Dictionary<StatEnum, float> _statDict;
    public Dictionary<StatEnum, float> StatDict 
    {
        get 
        {
            if (_statDict == null)
            {
                _statDict = new Dictionary<StatEnum, float>();
                foreach (var stat in monsterStats)
                {
                    if (_statDict.ContainsKey(stat.stats))
                    {
                        continue;
                    }
                    _statDict.Add(stat.stats, stat.value);
                }
            }
            return _statDict;
        }
    }
    [Header("MakeMoster")]
    public GameObject monsterPrefab;
    public int buyMonster;
    public float cooldTime;
}

[Serializable]
public class MonsterStats
{
    public StatEnum stats;
    public float value;
}
