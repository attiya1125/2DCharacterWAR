using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI goldTxt;
    [SerializeField] private Transform makeMonster;

    private int _level = 1;
    public int Level
    {
        get { return _level; }
        set { Level = value; } 
    }
    private int _gold;
    public int Gold
    {
        get { return _gold; }
        set { _gold = value; } 
    }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Gold = 0;
        StartCoroutine(UpGold());
    }

    private void Update()
    {
        goldTxt.text = "Gold : " + _gold.ToString();
    }

    IEnumerator UpGold()
    {
        while (true)
        {
            SetGold();
            yield return new WaitForSeconds(1f);
        }
    }

    private void SetGold()
    {
        Gold += (10 * Level);
    }

    public void MakeMonster(MonsterSO monsterSO)
    {
        Instantiate(monsterSO.monsterPrefab, makeMonster.position, Quaternion.identity);
    }
}
