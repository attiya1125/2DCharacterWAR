using UnityEngine;

public class StartBtn : MonoBehaviour
{
    [SerializeField] MonsterInventoryManager inventoryManager;
    public void OnClickStartBtn()
    {
        StartSceneManager.Instance.OnClickStartBtn(inventoryManager);
    }
}
