using System.Collections.Generic;
using UnityEngine;

public class MonsterInventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject selectedSlotPrefab;
    public List <SelectedSlot> slots;
    public List<InvenSlot> invenSlots;

    public Transform monseterSelectedPlace;
    private void Start()
    {
        slots = new List<SelectedSlot>();

        foreach (var nowData in DataManager.Instance.MonsterData)
        {
            SelectedSlot now = Instantiate(selectedSlotPrefab, monseterSelectedPlace).GetComponent<SelectedSlot>();
            slots.Add(now);
            now.AwakeSlot(nowData.Key, nowData.Value, this);
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
        for (int i = 0; i < invenSlots.Count; i++)
        {
            if (invenSlots[i].monsterSO == null)
            {
                return invenSlots[i];
            }
        }
        return null;
    }
}
