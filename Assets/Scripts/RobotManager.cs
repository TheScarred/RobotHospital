using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotManager : MonoBehaviour
{
    RobotProfile current;

    // Start is called before the first frame update
    void Start()
    {
        // current = Next();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        current = QueueController.GetInstance().GetNext();
        QueueController.GetInstance().Pop(current.id);
    }
}
