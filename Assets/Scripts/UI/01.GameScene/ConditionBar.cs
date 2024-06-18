using UnityEngine;
using UnityEngine.UI;

public class ConditionBar : MonoBehaviour
{
    public float curValue;
    public float maxValue;

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
        hpBar.fillAmount = hpPercentage;
    }
    void SetValue()
    {
        if (this.gameObject.CompareTag("Enemy"))
        {
            curValue = monster.StatDict[StatEnum.Hp] * (DataManager.Instance.stageManager.Stage);
        }
        else
        {
            curValue = monster.StatDict[StatEnum.Hp] * DataManager.Instance.MonsterData[monster];
        }
        maxValue = curValue;
        UpdateHpBar(curValue / maxValue);
    }

    public void Subtract(float value)
    {
        curValue = Mathf.Max(curValue - value, 0);
        UpdateHpBar(curValue / maxValue);
    }
}
