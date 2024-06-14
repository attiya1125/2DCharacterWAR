using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedSlot : MonoBehaviour
{
    [SerializeField] private MonsterSelectedPlace monsterSelectedPlace;
    public MonsterSO monsterSO;
    [SerializeField] private Image icon;
    public bool isSelected = false;
    [SerializeField] private TextMeshProUGUI levelTxt;

    public int levelData;

    private int _level = 1;
    public int Level
    {
        get { return _level; } 
        set 
        {
            _level = value;
            levelTxt.text = _level.ToString();
            levelData = _level;
        }
    }

    public void OnClickBtn()
    {
        if (isSelected)
        {
            return;
        }
        monsterSelectedPlace.AddInven(monsterSO);
        isSelected = true;
    }
    public void SetSlot(int level)
    {
        icon.sprite = monsterSO.monsterIcon;
        Level = level;
    }
}
