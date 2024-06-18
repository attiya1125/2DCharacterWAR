using UnityEngine;

public class MonsterCondition : MonoBehaviour, IDamageable
{
    [SerializeField] private MonsterSO monsterSO;
    [SerializeField] private MonsterObject monster;
    [SerializeField] private ConditionBar conditionBar;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        monster = GetComponent<MonsterObject>();
        monsterSO = monster.monsterSO;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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

    public void TakeDamage(float damage, Vector2 attackDirection)
    {
        int Ran = Random.Range(0, 100);
        if (Ran < 15)
        {
            animator.SetTrigger("isAttack");
            rb.AddForce(attackDirection.normalized * 3f, ForceMode2D.Impulse);
        }
        conditionBar.Subtract(damage);
    }
}
