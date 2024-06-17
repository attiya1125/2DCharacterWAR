using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public MonsterSO monsterSO;
    public MonsterSlot slot;
    public TextMeshProUGUI gold;
    public Image icon;
    public Image timeIcon;

    [SerializeField] float nowTime = 0f;
    public float time;
    public int index;

    public bool canMakeMonster = true;

    [SerializeField] private Transform makePosition;

    public void Init(MonsterSlot monsterSlot, int i)
    {
        slot = monsterSlot;
        index = i;
    }

    public void Clear()
    {
        monsterSO = null;
        icon.sprite = null;
        gold.text = null;
    }

    public void SetSlot()
    {
        icon.sprite = monsterSO.monsterIcon;
        time = monsterSO.cooldTime;
        gold.text = monsterSO.buyMonster.ToString();
    }
    void Update()
    {
        if (!canMakeMonster)
        {
            timeIcon.gameObject.SetActive(true);
            nowTime += Time.deltaTime;
            timeIcon.fillAmount = Mathf.Clamp01(1-(nowTime / time));

            if (timeIcon.fillAmount == 0)
            {
                canMakeMonster = true;
                timeIcon.gameObject.SetActive(false);
                nowTime = 0f;
            }
        }
    }
    public void OnClickSlot()
    {
        if (canMakeMonster)
        {
            MakeMonster(monsterSO);
            canMakeMonster = false;
        }
    }

    void MakeMonster(MonsterSO monsterSO)
    {
        Instantiate(monsterSO.monsterPrefab, makePosition.position, Quaternion.identity);
    }
}
