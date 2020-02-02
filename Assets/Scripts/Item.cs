using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public new SpriteRenderer renderer;
    public ItemType type;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = GameManager.GetInstance().sprites[(int)type];
    }
}
