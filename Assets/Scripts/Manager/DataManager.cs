using UnityEngine;
using System.Collections.Generic;

public class DataManager : Singleton<DataManager>
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

    public MonsterSelectedPlace selectedPlace;
    private void Awake()
    {
        List<MonsterSO> monsters = new List<MonsterSO>();
        List<int> levels = new List<int>();
        selectedPlace.Init();

        for (int i = 0; i < selectedPlace.slots.Length; i++)
        {
            monsters.Add(selectedPlace.slots[i].monsterSO);
            levels.Add(selectedPlace.slots[i].Level);
        }

        InitializeData(monsters, levels);
    }
    // ÄÁÆ®·Ñ K+C

    public void SetLevel(MonsterSO monsterSO, int level)
    {
        MonsterData[monsterSO] = level;
    }
}
