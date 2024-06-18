using UnityEngine;
using System.Collections.Generic;

public class DataManager : Singleton<DataManager>
{
    [HideInInspector] public MonsterManager monsterManager;
    [HideInInspector] public ExpManager expManager;
    [HideInInspector] public StageManager stageManager;

    public List<MonsterSO> selectedMonsterSO;

    // ÄÁÆ®·Ñ K+C
    protected override void Awake()
    {
        base.Awake();
        monsterManager = GetComponent<MonsterManager>();
        expManager = GetComponent<ExpManager>();
        stageManager = GetComponent<StageManager>();
        selectedMonsterSO = new List<MonsterSO>();
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
