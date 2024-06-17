using TMPro;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerExpTxt;

    private void Update()
    {
        playerExpTxt.text = $"Exp : {DataManager.Instance.expManager.PlayerExp}";
    }
}
