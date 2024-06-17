using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedSlot : MonoBehaviour
{
    public MonsterInventoryManager monsterInventoryManager;
    public MonsterSO monsterSO;
    public bool isSelected = false;

    [Header("UI")]
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private Button levelUpBtn;
    [SerializeField] private TextMeshProUGUI levelBtnTxt;

    private int _level = 1;
    public int Level
    {
        get { return _level; } 
        set 
        {
            _level = value;
            SetText(_level);
        }
    }

    public void OnClickBtn()
    {
        if (isSelected)
        {
            return;
        }
        monsterInventoryManager.AddInven(monsterSO);
        isSelected = true;
    }

    public void OnClickLevelUpBtn()
    {
        bool isLevelUp = DataManager.Instance.SubtractExp(Level * monsterSO.exp);
        if (isLevelUp)
        {
            Level = _level+1;
        }
    }
    void SetText(int level)
    {
        levelTxt.text = $"Lv.{Level}";
        levelBtnTxt.text = $"Exp : {level * monsterSO.exp}";
    }

    public void AwakeSlot(MonsterSO monsterSO, int level, MonsterInventoryManager monsterInventory)
    {
        monsterInventoryManager = monsterInventory;
        this.monsterSO = monsterSO;
        icon.sprite = monsterSO.monsterIcon;
        Level = level;
    }
}
