using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObject : MonoBehaviour
{
    public MonsterSO monsterSO;

    public float GetStat(StatEnum stat)
    {
        return monsterSO.StatDict[stat];
    }
}
