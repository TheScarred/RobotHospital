using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float hp = 100f;
    public float dps;

    private void Start()
    {
        InvokeRepeating("TakeDamage", 1f, 1f);
    }

    private void TakeDamage()
    {
        hp -= dps;
        Debug.Log("HP is: " + hp);
    }

}
