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

    
}
