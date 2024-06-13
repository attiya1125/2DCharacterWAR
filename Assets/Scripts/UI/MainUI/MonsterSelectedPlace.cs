using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelectedPlace : MonoBehaviour
{
    public SelectedSlot[] slots;

    public Transform monseterSelectedPlace;

    public MonsterSO monsterSO;

    void Start()
    {
        slots = new SelectedSlot[monseterSelectedPlace.childCount];

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = monseterSelectedPlace.GetChild(i).GetComponent<SelectedSlot>();
        }
    }
}
