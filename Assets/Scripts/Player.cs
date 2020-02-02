using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    public PlayerController controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("oven"))
        {

        }
    }
}
