using System.Collections;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldTxt;

    public int[] maxGold = { 200, 300, 500, 700, 1000 };

    private int _gold;
    public int Gold
    {
        get { return _gold; }
        set { _gold = value; }
    }

    private void Update()
    {
        goldTxt.text = $"Gold : {Gold} / {maxGold[GameManager.instance.levelManager.Level - 1]}"; 
    }

    public void UpGold()
    {
        StartCoroutine(UperGold());
    }

    IEnumerator UperGold()
    {
        while (true)
        {
            SetGold(GameManager.instance.levelManager.Level);
            yield return new WaitForSeconds(2f);
        }
    }

    private void SetGold(int level)
    {
        if (Gold >= maxGold[level - 1])
        {
            Gold = maxGold[level - 1];
            return;
        }
        Gold += (10 * level);
    }
}
