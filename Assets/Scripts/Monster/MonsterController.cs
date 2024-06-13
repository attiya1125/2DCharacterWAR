using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] private MonsterObject monster;
    [SerializeField] private LayerMask targetLayer;
    void Awake()
    {
        monster = GetComponent<MonsterObject>();
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, monster.GetStat(StatEnum.AttackDictance), targetLayer);
        if (hit.collider != null)
        {
            
        }
        else
        {
            transform.Translate(Vector2.right * monster.GetStat(StatEnum.Speed) * Time.deltaTime);
        }
        Debug.DrawRay(transform.position, Vector2.right * monster.GetStat(StatEnum.Speed), Color.red);
    }
}
