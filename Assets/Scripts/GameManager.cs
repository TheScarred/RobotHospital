using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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

    public PlayerController player;

    private List<Item> items;
    public List<Item> Items { get { return items; } }

    public int RobotID { get; set; } = 0;
    public int ItemID { get; set; } = 0;

    public TextMeshProUGUI local;
    private int money=2500;
    public int Money{
        get { return money; }
        set {money=value;
            local.text = "$ " + money.ToString(); ;
        }
    }

    private void Start()
    {
        items = new List<Item>();
    }
}
