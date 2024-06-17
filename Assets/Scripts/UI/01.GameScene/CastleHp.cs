using UnityEngine;
using UnityEngine.UI;

public class CastleHp : MonoBehaviour, IDamageable
{
    [SerializeField] private float curValue;
    [SerializeField] private float maxValue;

    public Image hpBar;

    private void Start()
    {
        SetValue();
    }

    void Update()
    {
        if (hpBar.fillAmount == 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void UpdateHpBar(float hpPercentage)
    {
        hpBar.fillAmount = hpPercentage;
    }
    void SetValue()
    {
        UpdateHpBar(curValue / maxValue);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("?");
        curValue = Mathf.Max(curValue - damage, 0);
        UpdateHpBar(curValue / maxValue);
    }
}
