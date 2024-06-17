using UnityEngine;

public class StageManager : MonoBehaviour
{
    private int _stage = 1;
    public int Stage 
    { 
        get { return _stage; } 
        set { _stage = value; }
    }
}
