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

    public int RobotID { get; set; } = 0;
    public int ItemID { get; set; } = 0;
    public int Money { get; set; } = 1000;
}
