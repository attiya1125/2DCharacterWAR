using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector] public LevelManager levelManager;
    [HideInInspector] public GoldManager goldManager;
    [SerializeField] private Transform makeMonster;

    private void Awake()
    {
        instance = this;
        levelManager = GetComponent<LevelManager>();
        goldManager = GetComponent<GoldManager>();
    }

    private void Start()
    {
        goldManager.Gold = 0;
        goldManager.UpGold();
        levelManager.SetLevelTxt();
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
}
