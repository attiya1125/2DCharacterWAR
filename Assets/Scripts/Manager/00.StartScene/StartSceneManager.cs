using UnityEngine.SceneManagement;

public class StartSceneManager : Singleton<StartSceneManager>
{
    public MonsterInventoryManager monsterInventoryManager;
    public void OnClickStartBtn()
    {
        DataManager.Instance.selectedMonsterSO.Clear();

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
    
