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
        for (byte i = 0; i < profiles.Length; i++)
        {
            profiles[i] = ScriptableObject.CreateInstance<RobotProfile>();
            profiles[i].Init(GameManager.GetInstance().RobotID++, false);
        }
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

    public void Pop(int _id)
    {
        for (byte i = 0; i < profiles.Length; i++)
        {
            if (profiles[i] != null && profiles[i].id == _id)
                profiles[i] = null;
        }
    }


}
