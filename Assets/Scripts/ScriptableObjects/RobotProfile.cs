using UnityEngine;

[CreateAssetMenu(fileName = "Robot Profile", menuName = "Robot Card")]
public class RobotProfile : ScriptableObject
{
    public int id;
    public Heart hp;
    public Sprite robot;
    public bool isNext;

    public Sprite Head;
    public Sprite HeadBr;

    public Sprite Body;
    public Sprite BodyBr;
    
    public Sprite Legs;
    public Sprite LegsBr;

    int bitmap;

    public int BitMap
    {
        get { return bitmap; }
    }

    public void Init(int _id, bool _isNext,int condition)
    {
        id = _id;
        isNext = _isNext;
        bitmap = 1 << condition;
    }

}
