using UnityEngine;

[CreateAssetMenu(fileName = "Robot Profile", menuName = "Robot Card")]
public class RobotProfile : ScriptableObject
{
    public Heart hp;
    public Sprite robot;
    public bool isNext;

    public void Init()
    {

    }

}
