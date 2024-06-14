using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInventoryManager : Singleton<MonsterInventoryManager>
{
    public SelectedSlot[] slots;
    public Transform monseterSelectedPlace;
    private void Awake()
    {
        slots = new SelectedSlot[monseterSelectedPlace.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = monseterSelectedPlace.GetChild(i).GetComponent<SelectedSlot>();
        }
    }

    private void Start()
    {
        foreach (var slot in slots)
        {
            slot.SetSlot(DataManager.Instance.MonsterData[slot.monsterSO]);
        }
    }
}
