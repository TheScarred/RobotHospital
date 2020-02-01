using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Store", menuName = "Store")]
public class Store : ScriptableObject
{
    public Item item;
    public int cost;
}
