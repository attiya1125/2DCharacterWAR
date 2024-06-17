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
        int layerNumber = Mathf.RoundToInt(Mathf.Log(targetLayer.value, 2));

        if (layerNumber == 7)
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
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, monster.GetStat(StatEnum.AttackDictance), targetLayer);
        if (hit.collider != null)
        {
            Debug.Log(monster.GetStat(StatEnum.Atk));
        }
        else
        {
            transform.Translate(direction * monster.GetStat(StatEnum.Speed) * Time.deltaTime);
        }
        Debug.DrawRay(transform.position, direction * monster.GetStat(StatEnum.AttackDictance), Color.red);
    }
}
