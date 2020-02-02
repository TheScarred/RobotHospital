using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Furnace Part", menuName = "Furnace")]
public class Furnace : ScriptableObject
{
    public Transform spawnPoint;
    public ItemType materialNeeded, result;
}
