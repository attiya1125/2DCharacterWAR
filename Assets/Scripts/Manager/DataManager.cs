using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
