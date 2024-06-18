using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private MonsterObject monster;
    [SerializeField] private LayerMask targetLayer;

    private bool canAttack = true;
    private float time;

    void Awake()
    {
        monster = GetComponent<MonsterObject>();
    }

    void Update()
    {
        if (!canAttack)
        {
            time += Time.deltaTime;
            if (time > monster.GetStat(StatEnum.AttackDelay))
            {
                canAttack = true;
                time = 0;
            }
        }

        if (this.gameObject.layer == 6)
        {
            Target(Vector2.left);
        }
        else
        {
            Target(Vector2.right);
        }
    }

    private void Target(Vector2 direction)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, monster.GetStat(StatEnum.AttackDictance), targetLayer);

        if (hits.Length != 0)
        {
            foreach (RaycastHit2D hit in hits)
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    if (canAttack)
                    {
                        if (this.gameObject.CompareTag("Enemy"))
                        {
                            damageable.TakeDamage(monster.GetStat(StatEnum.Atk) + (DataManager.Instance.stageManager.Stage * 2), direction);
                        }
                        else
                        {
                            damageable.TakeDamage(monster.GetStat(StatEnum.Atk) + (DataManager.Instance.MonsterData[monster.monsterSO] * 2), direction);
                        }
                    }
                }
            }
            canAttack = false;
        }
        else
        {
            transform.Translate(direction * monster.GetStat(StatEnum.Speed) * Time.deltaTime);
        }
        Debug.DrawRay(transform.position, direction * monster.GetStat(StatEnum.AttackDictance), Color.red);
    }
}
