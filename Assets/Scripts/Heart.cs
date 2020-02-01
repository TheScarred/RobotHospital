using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public float value = 100f;
    public float dps = 0.1f;

    private void Start()
    {
        InvokeRepeating("TakeDamage", 1f, 1f);
    }

    private void TakeDamage()
    {
        value -= dps;
        Debug.Log("HP is: " + value);
    }

}
