using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSlot : MonoBehaviour
{
    public Slot[] slots;

    public Transform monsterSlots;

    public MonsterSO monsterSO;

    void Start()
    {
        slots = new Slot[monsterSlots.childCount];

        for(int i = 0; i < slots.Length; i++)
        {
            slots[i] = monsterSlots.GetChild(i).GetComponent<Slot>();
            slots[i].Init(this, i);
        }

        UpdateSlot();
    }

    public void UpdateSlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].monsterSO != null)
            {
                slots[i].SetSlot();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    public void AddMonster(MonsterSO monsterData)
    {
        Debug.Log(monsterData);
        for(int i = 0; i < slots.Length; i++)
        {
            Debug.Log(slots[i]);
            if (slots[i].monsterSO == null)
            {
                slots[i].monsterSO = monsterData;
                UpdateSlot();
                return;
            }
        }
    }

    public void DeleteMonster(int index)
    {
        if (slots[index].monsterSO != null)
        {
            slots[index].monsterSO = null;  
        }
        UpdateSlot();
    }
}
