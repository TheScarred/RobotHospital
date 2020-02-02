using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    PlayerController player;
    public int id;
    public new SpriteRenderer renderer;
    public ItemType type;
    public bool IsGrab;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Start()
    {
        IsGrab = false;
        renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = GameManager.GetInstance().sprites[(int)type];
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsGrab)
        {
            switch (type)
            {
                case (ItemType.METAL):
                {
                    if(collision.CompareTag("Oven") && !collision.GetComponent<FurnaceProfile>().Craft) {
                            collision.GetComponent<FurnaceProfile>().StartCraft();
                            Destroy(this.gameObject);
                    }
                    else if (collision.CompareTag("Recicle")){
                            //Missing
                    }
                    

                    break;
                }
                case (ItemType.BATTERY):
                {
                    if (collision.CompareTag("Generator"))
                    {
                            PowerGenerator gen = collision.GetComponent<PowerGenerator>();
                            if (gen.battery == null)
                            {
                                collision.GetComponent<PowerGenerator>().CreateBattery();
                                Destroy(this.gameObject);
                            }
                        
                    }
                    else if (collision.CompareTag("Recicle"))
                    {
                        //Missing
                    }

                    break;
                }
            }
        }
    }
}
