using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    HEAD,
    ARM,
    LEG,
    METAL,
    BATTERY
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

    public Sprite[] sprites;

    private List<Player> players;
    public List<Player> Players { get { return players; } }

    private List<Item> items;
    public List<Item> Items { get { return items; } }

    public int RobotID { get; set; } = 0;
    public int ItemID { get; set; } = 0;
    public int Money { get; set; } = 2500;

    private void Start()
    {
        items = new List<Item>();
        players = new List<Player>(2);
    }
}
