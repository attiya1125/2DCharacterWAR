using UnityEngine;
using System.Collections.Generic;

public class DataManager : Singleton<DataManager>
{
    [HideInInspector] public MonsterManager monsterManager;
    [HideInInspector] public ExpManager expManager;

    // ÄÁÆ®·Ñ K+C
    private void Awake()
    {
        monsterManager = GetComponent<MonsterManager>();
        expManager = GetComponent<ExpManager>();
    }
    public Dictionary<MonsterSO, int> MonsterData
    {
        get
        {
            return monsterManager.MonsterData;
        }
    }
    public void ChangeLevel(MonsterSO monsterSO, int level)
    {
        monsterManager.ChangeLevel(monsterSO, level);
    }

    public bool SubtractExp(int exp)
    {
        return expManager.SubtractExp(exp);
    }
}
