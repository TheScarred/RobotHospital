using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Profile", menuName = "Item")]
public class ItemProfile : ScriptableObject
{
    public GameObject prefab;
    public int id;

    public int ID()
    {
        return GameManager.GetInstance().ItemID++;
    }
}
