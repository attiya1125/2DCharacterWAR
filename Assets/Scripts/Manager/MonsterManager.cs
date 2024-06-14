using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public class DataEntry
    {
        public MonsterSO monsterSO;
        public int level;

        public DataEntry(MonsterSO monsterSO, int level)
        {
            this.monsterSO = monsterSO;
            this.level = level;
        }
    }

    public List<DataEntry> dataList = new List<DataEntry>();
    public void AddMonterData(MonsterSO monsterSO, int level)
    {
        dataList.Add(new DataEntry(monsterSO, level));
    }

    private Dictionary<MonsterSO, int> _monseterData;
    public Dictionary<MonsterSO, int> MonsterData
    {
        get
        {
            if (_monseterData == null)
            {
                _monseterData = new Dictionary<MonsterSO, int>();
            }
            return _monseterData;
        }
    }

    public void InitializeData(List<MonsterSO> monsters, List<int> levels)
    {
        if (monsters.Count != levels.Count)
        {
            return;
        }

        for (int i = 0; i < monsters.Count; i++)
        {
            MonsterData[monsters[i]] = levels[i];
        }
    }
    public List<MonsterSO> monsterSOs;
    private void Awake()
    {
        List<int> levels = new List<int>();

        for (int i = 0; i < monsterSOs.Count; i++)
        {
            levels.Add(1);
        }

        InitializeData(monsterSOs, levels);
    }

    public void ChangeLevel(MonsterSO monsterSO, int level)
    {
        MonsterData[monsterSO] = level;
    }
}
