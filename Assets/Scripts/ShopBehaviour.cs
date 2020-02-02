using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBehaviour : MonoBehaviour
{
    public Shop store;

    public void Purchase(Collider2D col)
    {
        GameManager.GetInstance().Money -= store.cost;
        SpawnItem();
    }

    public void SpawnItem()
    {
        SearchPool();
    }

    public GameObject SearchPool()
    {
        List<Item> items = GameManager.GetInstance().Items;

        for (byte i = 0; i < items.Count; i++)
        {
            if (!items[i].gameObject.activeSelf)
            {
                GameObject obj = items[i].gameObject;
                Respawn(ref obj);
                return obj;
            }
        }
        return Spawn();
    }

    public void Respawn(ref GameObject _obj)
    {
        GameObject obj = _obj;
        SetSprite(ref _obj);

        Item item = obj.GetComponent<Item>();
        item.GetComponent<Item>().id = store.item.ID();
        item.transform.position = new Vector3(0, 0, -0.5f);
        item.gameObject.SetActive(true);
    }

    public GameObject Spawn()
    {
        GameObject newGO = Instantiate(store.item.prefab);
        Item newItem = newGO.GetComponent<Item>();
        newItem.id = store.item.ID();
        GameManager.GetInstance().Items.Add(newItem);

        return newItem.gameObject;
        
    }

    public void SetSprite(ref GameObject _obj)
    {
        _obj.GetComponent<SpriteRenderer>().sprite = GameManager.GetInstance().sprites[(int)store.type];
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Purchase(col);
        }
    }
    
}
