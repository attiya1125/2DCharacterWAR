using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMonsterController : MonoBehaviour
{
    [SerializeField] private MonsterObject monster;
    [SerializeField] private LayerMask targetLayer;
    void Awake()
    {
        monster = GetComponent<MonsterObject>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, monster.GetStat(StatEnum.AttackDictance), targetLayer);
        if (hit.collider != null)
        {

        }
        else
        {
            transform.Translate(Vector2.left * monster.GetStat(StatEnum.Speed) * Time.deltaTime);
        }
        Debug.DrawRay(transform.position, Vector2.left * monster.GetStat(StatEnum.AttackDictance), Color.red);
    }
}
