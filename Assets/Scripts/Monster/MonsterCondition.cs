using UnityEngine;

public class MonsterCondition : MonoBehaviour, IDamageable
{
    [SerializeField] private MonsterSO monsterSO;
    [SerializeField] private MonsterObject monster;
    [SerializeField] private ConditionBar conditionBar;

    private void Awake()
    {
        monster = GetComponent<MonsterObject>();
        monsterSO = monster.monsterSO;
    }

    private void Update()
    {
        if (conditionBar.hpBar.fillAmount == 0)
        {
            if (this.gameObject.tag == "Enemy")
            {
                DataManager.Instance.expManager.PlayerExp += monsterSO.exp;
                GameManager.instance.goldManager.Gold += monsterSO.gold;
            }
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        conditionBar.Subtract(damage);
    }
}
