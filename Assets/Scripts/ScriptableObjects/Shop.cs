using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Store", menuName = "Store")]
public class Shop : ScriptableObject
{
    public Transform spawnPoint;
    public ItemProfile item;
    public ItemType type;
    public int cost;
}
