using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCastle : MonoBehaviour, IDamageable
{
    [SerializeField] private float curValue;
    [SerializeField] private float maxValue;

    [SerializeField] private MonsterSO[] monsterSOs;
    [SerializeField] private Transform makeMonster;

    [SerializeField] private TextMeshProUGUI castleHp;
    public Image hpBar;

    private void Start()
    {
        SetValue();
        SetCastleHpText();
        StartCoroutine(MakeMonsters(DataManager.Instance.stageManager.Stage));
    }

    void Update()
    {
        if (hpBar.fillAmount == 0)
        {
            GameManager.instance.EndGame();
            Destroy(this.gameObject);
        }
    }
    public void UpdateHpBar(float hpPercentage)
    {
        hpBar.fillAmount = hpPercentage;
    }
    void SetValue()
    {
        SetCastleHp();
        UpdateHpBar(curValue / maxValue);
    }
    void SetCastleHpText()
    {
        castleHp.text = $"{maxValue}/{curValue}";
    }

    private void SetCastleHp()
    {
        curValue *= DataManager.Instance.stageManager.Stage;
        maxValue = curValue;
    }

    public void TakeDamage(float damage, Vector2 vector2)
    {
        curValue = Mathf.Max(curValue - damage, 0);
        UpdateHpBar(curValue / maxValue);
        SetCastleHpText();
    }

    void InstantiateMonster(int stage)
    {
        switch (stage)
        {
            case 1:
                Instantiate(monsterSOs[0].monsterPrefab, makeMonster.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(monsterSOs[Random.Range(0, 2)].monsterPrefab, makeMonster.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(monsterSOs[Random.Range(0, 3)].monsterPrefab, makeMonster.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(monsterSOs[Random.Range(0, 4)].monsterPrefab, makeMonster.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(monsterSOs[4].monsterPrefab, makeMonster.position, Quaternion.identity);
                break;
        }
    }
    IEnumerator MakeMonsters(int stage)
    {
        while (true)
        {
            InstantiateMonster(stage);
            int rand = Random.Range(0, 100);
            if (rand / stage <= 15)
            {
                InstantiateMonster(stage);
            }
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }
}
