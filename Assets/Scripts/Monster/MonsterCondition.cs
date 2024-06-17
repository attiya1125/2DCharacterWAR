using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCondition : MonoBehaviour, IDamageable
{
    [SerializeField] private MonsterSO monsterSO;
    [SerializeField] private MonsterObject monster;
    [SerializeField] private ConditionBar conditionBar;

    private bool isDead = false;

    private void Awake()
    {
        monster = GetComponent<MonsterObject>();
        monsterSO = monster.monsterSO;
    }

    private void Update()
    {
        if (conditionBar.hpBar.fillAmount == 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        conditionBar.Subtract(damage);
    }
}
