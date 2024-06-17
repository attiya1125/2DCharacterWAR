using UnityEngine.SceneManagement;

public class StartSceneManager : Singleton<StartSceneManager>
{
    public MonsterInventoryManager monsterInventoryManager;
    public void OnClickStartBtn(MonsterInventoryManager monsterInventory)
    {
        DataManager.Instance.selectedMonsterSO.Clear();

        if (monsterInventoryManager == null)
        {
            monsterInventoryManager = monsterInventory;
        }

        foreach(var data in monsterInventoryManager.invenSlots)
        {
            if (data.monsterSO == null)
            {
                continue;
            }
            DataManager.Instance.selectedMonsterSO.Add(data.monsterSO);
        }
        SceneManager.LoadScene(1);
    }
}
    
