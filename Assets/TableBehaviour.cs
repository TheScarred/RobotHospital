using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehaviour : MonoBehaviour
{
    FullTableBehaviour table;
    Animator doors;
    public static bool finish = false;
    public string tag;
    // Start is called before the first frame update
    void Start()
    {
        doors = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tag) && collision.GetComponent<Item>() && transform.childCount == 0)
        {
            PlayerController player = GameManager.GetInstance().player;
            player.objectRef = null;
            player.handsUp = false;
            collision.transform.position = transform.position;
            collision.transform.parent = transform;

            if (FullTableBehaviour.GetInstance().Check())
            {
                doors.SetTrigger("ChangeRobot");
            }
        }
    }
}
