using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueController : MonoBehaviour
{
    #region SINGLETON
    private static QueueController instance;
    public static QueueController GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public RobotProfile[] profiles;

    private void Start()
    {
        profiles[0] = ScriptableObject.CreateInstance<RobotProfile>();
        profiles[0].isNext = false;
        profiles[1] = ScriptableObject.CreateInstance<RobotProfile>();
        profiles[1].isNext = false;
        profiles[2] = ScriptableObject.CreateInstance<RobotProfile>();
        profiles[2].isNext = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SpotAvailable()
    {
        for (byte i = 0; i < profiles.Length; i++)
        {
            if (profiles[i] == null)
                return true;
        }
        return false;
    }

    public RobotProfile GetNext()
    {
        for (byte i = 0; i < profiles.Length; i++)
        {
            if (profiles[i] != null && profiles[i].isNext)
                return profiles[i];
        }
        return null;
    }


}
