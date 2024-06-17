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
        
    }
}
