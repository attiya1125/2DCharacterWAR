using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CastleHp : MonoBehaviour, IDamageable
{
    [SerializeField] private float curValue;
    [SerializeField] private float maxValue;

    [SerializeField] private TextMeshProUGUI castleHp;

    public Image hpBar;

    private void Start()
    {
        SetValue();
        SetHpTxt();
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
    void SetHpTxt()
    {
        castleHp.text = $"{maxValue}/{curValue}";
    }

    public void TakeDamage(float damage)
    {
        curValue = Mathf.Max(curValue - damage, 0);
        UpdateHpBar(curValue / maxValue);
        SetHpTxt() ;
    }
}
