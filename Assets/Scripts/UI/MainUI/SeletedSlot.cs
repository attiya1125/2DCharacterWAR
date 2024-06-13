using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedSlot : MonoBehaviour
{
    [SerializeField] private MonsterSO monsterSO;
    [SerializeField] private Image icon;
    [SerializeField] private bool isSelected = false;
    [SerializeField] private TextMeshProUGUI levelTxt;

    private int _Level;
    public int Level
    {
        get { return _Level; } 
        set 
        { 
            _Level = value;
            levelTxt.text = _Level.ToString();
        }
    }

    public void OnClickBtn()
    {
        if (isSelected)
        {
            return;
        }
        DataManager.Instance.AddMonterData(monsterSO, _Level);
        isSelected = true;
    }

    public void Start()
    {
        Level = 5;
    }
}
