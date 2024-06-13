using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : Singleton<DataManager>
{
    public MonsterSO monsterSO;
    [SerializeField] private MonsterSlot slot;

    public void Awake()
    {

    }

    public void SetSlot()
    {
        Debug.Log("?");
        slot.AddMonster(monsterSO);
    }
}
