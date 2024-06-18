using TMPro;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    [SerializeField] MonsterInventoryManager inventoryManager;
    [SerializeField] TextMeshProUGUI stageTxt;

    int count = 0;
    public void OnClickStartBtn()
    {
        count = 0;
        foreach (var inventory in inventoryManager.invenSlots)
        {
            if (inventory.monsterSO != null)
            {
                count++;
            }
        }

        if (count == 0)
        {
            return;
        }
        int i = int.Parse(stageTxt.text);
        StartSceneManager.Instance.OnClickStartBtn(inventoryManager, i);
    }
}
