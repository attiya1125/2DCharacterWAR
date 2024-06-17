using UnityEngine;

public class StageManager : MonoBehaviour
{
    private int _stage;
    public int Stage 
    { 
        get { return _stage; } 
        set { _stage = value; }
    }
}
