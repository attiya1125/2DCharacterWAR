using System;
using UnityEngine;
using UnityEngine.UI;

public class ConditionBar : MonoBehaviour
{
    public float curValue;
    public float maxValue;
    public float startValue;

    public Image hpBar;

    [SerializeField] private MonsterObject monsterObject;
    [SerializeField] private MonsterSO monster;

    private void Start()
    {
        monsterObject = GetComponentInParent<MonsterObject>();

        if (monsterObject != null)
        {
            monster = monsterObject.monsterSO;
            SetValue();
        }
    }
    public void UpdateHpBar(float hpPercentage)
    {
        hpBar.fillAmount = Mathf.Clamp01(hpPercentage);
    }
    void SetValue()
    {
        curValue = monster.StatDict[StatEnum.Hp];
        startValue = curValue;
        UpdateHpBar(curValue / startValue);
    }
}
