using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class test_modifyTMP : MonoBehaviour
{
    TextMeshProUGUI local;
    // Start is called before the first frame update
    void Start()
    {
        local = GetComponent<TextMeshProUGUI>();
        local.text = "Hola mundo";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
