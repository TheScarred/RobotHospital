using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullTableBehaviour : MonoBehaviour
{
    #region SINGLETON
    private static FullTableBehaviour instance;
    public static FullTableBehaviour GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public bool Check()
    {
        bool complete=true;
        RobotPart [] parts= GetComponentsInChildren<RobotPart>();
        for(byte i=0; i<parts.Length; i++)
        {
            complete= complete && parts[i].IsBroken;
        }
        Debug.Log(complete);
        return complete;
    }
}
