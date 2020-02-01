using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Furnace 1", menuName = "Furnace")]
public class Furnace : ScriptableObject
{
    public Transform spawnPoint;
    public Item materialNeeded, result;
}
