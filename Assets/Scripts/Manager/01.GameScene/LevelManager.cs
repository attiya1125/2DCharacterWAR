using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelGoldTxt;
    [SerializeField] private Button levelUpBtn;

    private int[] levelUpGold = {100, 200, 300, 400, 500};
    private int _level = 1;
    public int Level
    {
        get { return _level; }
        set { _level = value; }
    }

    public void LevelUp(GoldManager goldManager)
    {
        if (goldManager.Gold >= levelUpGold[Level - 1])
        {
            goldManager.Gold -= levelUpGold[Level - 1];
            Level += 1;
            SetLevelTxt();
        }
    }

    public void SetLevelTxt()
    {
        levelGoldTxt.text = $"{levelUpGold[Level - 1]}";
    }

    public void MaxLevel()
    {
        levelUpBtn.interactable = false;
        levelGoldTxt.text = "Max";
    }
}
