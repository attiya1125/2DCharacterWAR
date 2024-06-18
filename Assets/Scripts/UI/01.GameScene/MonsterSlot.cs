using System.Collections.Generic;
using UnityEngine;

public class MonsterSlot : MonoBehaviour
{
    private List<Slot> slots;
    [SerializeField] private Transform monsterSlot;
    [SerializeField] private GameObject slotPrefabs;

    void Start()
    {
        slots = new List<Slot>();

        for (int i = 0;i < DataManager.Instance.selectedMonsterSO.Count; i++)
        {
            Slot slot = Instantiate(slotPrefabs, monsterSlot).GetComponent<Slot>();
            slots.Add(slot);
            slots[i].Init(this, i);
            slots[i].monsterSO = DataManager.Instance.selectedMonsterSO[i];
        }
        UpdateSlot();
    }

    public void UpdateSlot()
    {
        for (int i = 0; i < slots.Count; i++)
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
        for(int i = 0; i < slots.Count; i++)
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
