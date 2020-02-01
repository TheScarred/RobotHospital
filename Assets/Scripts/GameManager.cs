using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PartType
{
    HEAD,
    ARM,
    LEG
}

public class GameManager : MonoBehaviour
{
    #region SINGLETON
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private int robotID = 0;
    public int RobotID
    {
        get { return robotID; }
        set { robotID = value; }
    }

    private int itemID = 0;
    public int ItemID
    {
        get { return itemID; }
        set { itemID = value; }
    }
}
