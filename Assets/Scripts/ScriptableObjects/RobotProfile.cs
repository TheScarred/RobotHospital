using UnityEngine;

[CreateAssetMenu(fileName = "Robot Profile", menuName = "Robot Card")]
public class RobotProfile : ScriptableObject
{
    public int id;
    public bool isNext;
    public int start;

    public RegistrationCard card;


    public Sprite HeadImg;
    public Sprite ChestImg;
    public Sprite LegsImg;

    public Object Head;
    public Object HeadBr;

    public Object Chest;
    public Object ChestBr;

    public Object Legs;
    public Object LegsBr;

    public int piezasRotas;

    public void Init(int _id, bool _isNext,ref RegistrationCard c)
    {
        id = _id;
        isNext = _isNext;

        piezasRotas = Random.Range(0, 3);
 
        c.SetPieces(HeadImg, ChestImg, LegsImg);
    }

}
