using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{
    public Transform spawnPoint;
    public int id;

    public void Spawn(int _id)
    {
        id = _id;
    }
}
