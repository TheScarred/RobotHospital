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
    private int CurrentId;
    public Transform canvasUI;
    public RobotProfile[] orinals;
    public RobotProfile[] profiles;
    public Transform head, body, legs;
    public int[] positions;
    public Object card;

    public Transform [] partsParents;
    private void Start()
    {
        
        for (byte i = 0; i < profiles.Length; i++)
        {
            RegistrationCard.cardIndex++;
            GameObject temp = Instantiate(card, new Vector3(200,positions[i],0), Quaternion.identity, canvasUI) as GameObject;
            RegistrationCard component = temp.GetComponent<RegistrationCard>();
            int chose = Random.Range(0, orinals.Length);
            profiles[i] = orinals[chose];
            profiles[i].Init(GameManager.GetInstance().RobotID++, false, ref component);
        }
        
        GetNext();
        CurrentId = profiles[0].id;

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
        if(CurrentId!=0)
            Pop(CurrentId);

        for (byte i = 0; i < profiles.Length; i++)
        {
            if (profiles[i] != null)
            {
                Cases(profiles[i]);
                CurrentId = profiles[i].id;
                return profiles[i];
            }
                
        }
        return null;
    }

    public void Cases(RobotProfile robot)
    {
        RobotPart temp;
        GameObject obj=null;
        switch (robot.piezasRotas)
        {
            case 0:
                {
                    obj = Instantiate(robot.HeadBr, head.position, Quaternion.identity, head) as GameObject;
                    Instantiate(robot.Chest, body.position, Quaternion.identity, body);
                    Instantiate(robot.Legs, legs.position, Quaternion.identity, legs);
                    
                    break;
                }
            case 1:
                {
                    Instantiate(robot.Head, head.position, Quaternion.identity, head);
                    obj = Instantiate(robot.ChestBr, body.position, Quaternion.identity, body) as GameObject;
                    Instantiate(robot.Legs, legs.position, Quaternion.identity, legs);
                    break;
                }
            case 2:
                {
                    Instantiate(robot.Head, head.position, Quaternion.identity, head);
                    Instantiate(robot.Chest, body.position, Quaternion.identity, body);
                    obj = Instantiate(robot.LegsBr, legs.position, Quaternion.identity, legs) as GameObject;
                    break;
                }
        }
        temp = obj.GetComponent<RobotPart>();
        temp.IsBroken = false;
    }

    public void Pop(int _id)
    {
        for(byte i = 0; i < partsParents.Length; i++)
        {
            if(partsParents[i].childCount>0)
                Destroy(partsParents[i].GetChild(0).gameObject);
        }

        for (byte i = 0; i < profiles.Length; i++)
        {
            if (profiles[i] != null && profiles[i].id == _id)
                profiles[i] = null;
        }
    }


}
