using UnityEngine;

public class ExpManager : MonoBehaviour
{

    private int _playerExp;
    public int PlayerExp
    {
        get { return _playerExp; }
        set
        {
            _playerExp = value;
        }
    }

    public bool SubtractExp(int exp)
    {
        if (_playerExp >= exp)
        {
            _playerExp -= exp;
            return true;
        }
        return false;
    }
}
