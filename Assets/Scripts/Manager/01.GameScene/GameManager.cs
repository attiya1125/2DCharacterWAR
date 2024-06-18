using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public LevelManager levelManager;
    [HideInInspector] public GoldManager goldManager;
    [SerializeField] private Transform makeMonster;

    [SerializeField] private GameObject stageClearPanel;
    [SerializeField] private TextMeshProUGUI addExpTxt;
    [SerializeField] private TextMeshProUGUI stageClearTxt;

    int setExp;

    private void Awake()
    {
        instance = this;
        levelManager = GetComponent<LevelManager>();
        goldManager = GetComponent<GoldManager>();
    }

    private void Start()
    {
        goldManager.Gold = 1000;
        goldManager.UpGold();
        levelManager.SetLevelTxt();
        setExp = DataManager.Instance.expManager.PlayerExp;
    }

    public void OnClickLevelUpBtn()
    {
        levelManager.LevelUp(goldManager);
        if (levelManager.Level >= goldManager.maxGold.Length)
        {
            levelManager.MaxLevel();
            return;
        }
    }

    public void MakeMonster(MonsterSO monsterSO)
    {
        Instantiate(monsterSO.monsterPrefab, makeMonster.position, Quaternion.identity);
    }

    public void EndGame()
    {
        stageClearPanel.SetActive(true);
        addExpTxt.text = $"Exp : {setExp} -> {DataManager.Instance.expManager.PlayerExp}";
    }
    public void LoseGame()
    {
        DataManager.Instance.expManager.PlayerExp = setExp;
        stageClearPanel.SetActive(true);
        stageClearTxt.text = "Stage Failed";
        addExpTxt.text = $"Exp : {setExp} -> {DataManager.Instance.expManager.PlayerExp}";
    }
    public void GoStartScene()
    {
        SceneManager.LoadScene(0);
    }
}
