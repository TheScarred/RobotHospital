using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPart : Item
{
    bool isBroken = true;
    
    public bool IsBroken
    {
        get { return isBroken; }
        set { isBroken = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
