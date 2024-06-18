using UnityEngine;
using UnityEngine.UI;

public class InvenSlot : MonoBehaviour
{
    public MonsterInventoryManager monsterInventoryManager;
    public Image icon;
    public MonsterSO monsterSO;

    public void OnCilckInvenSlot()
    {
        if (monsterSO == null)
        {
            return;
        }
        for (int i = 0; i < monsterInventoryManager.slots.Count; i++)
        {
            if (monsterInventoryManager.slots[i].monsterSO == monsterSO)
            {
                monsterInventoryManager.slots[i].isSelected = false;
                monsterSO = null;
                icon.sprite = null;
                return;
            }
        }

    }
}
