using TMPro;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    [SerializeField] MonsterInventoryManager inventoryManager;
    [SerializeField] TextMeshProUGUI stageTxt;
    public void OnClickStartBtn()
    {
        int i = int.Parse(stageTxt.text);
        StartSceneManager.Instance.OnClickStartBtn(inventoryManager, i);
    }
}
