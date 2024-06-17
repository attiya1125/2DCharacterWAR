using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class DataManager : Singleton<DataManager>
{
    [HideInInspector] public MonsterManager monsterManager;
    [HideInInspector] public ExpManager expManager;

    public List<MonsterSO> selectedMonsterSO;

    // ��Ʈ�� K+C
    protected override void Awake()
    {
        base.Awake();
        monsterManager = GetComponent<MonsterManager>();
        expManager = GetComponent<ExpManager>();
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
