using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelectedPlace : MonoBehaviour
{
    public SelectedSlot[] slots;
    public InvenSlot[] invenSlots;

    public Transform monseterSelectedPlace;
    public Transform invenPlace;

    public void Init()
    {
        slots = new SelectedSlot[monseterSelectedPlace.childCount];
        invenSlots = new InvenSlot[invenPlace.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = monseterSelectedPlace.GetChild(i).GetComponent<SelectedSlot>();
        }


        for (int i = 0; i < invenSlots.Length; i++)
        {
            invenSlots[i] = invenPlace.GetChild(i).GetComponent<InvenSlot>();
        }
    }

    public void AddInven(MonsterSO monsterSO)
    {
        InvenSlot emptySlot = GetEmptySlot();
        if (emptySlot != null)
        {
            emptySlot.monsterSO = monsterSO;
            emptySlot.icon.sprite = monsterSO.monsterIcon;
            return;
        }
    }

    private InvenSlot GetEmptySlot()
    {
        for(int i = 0; i < invenSlots.Length; i++)
        {
            if (invenSlots[i].monsterSO == null)
            {
                return invenSlots[i];
            }
        }
        return null;
    }
}
