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
        StartCoroutine(MakeMonsters());
    }

    void Update()
    {
        if (hpBar.fillAmount == 0)
        {
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

    public void TakeDamage(float damage)
    {
        curValue = Mathf.Max(curValue - damage, 0);
        UpdateHpBar(curValue / maxValue);
        SetCastleHpText();
    }

    void InstantiateMonster()
    {
        Instantiate(monsterSOs[Random.Range(0,2)].monsterPrefab, makeMonster.position, Quaternion.identity);
    }
    IEnumerator MakeMonsters()
    {
        while (true)
        {
            InstantiateMonster();
            int rand = Random.Range(0, 100);
            if (rand <= 15)
            {
                InstantiateMonster();
            }
            yield return new WaitForSeconds(Random.Range(2, 5));
        }
    }
}
