using UnityEngine;

[CreateAssetMenu(fileName = "Robot Profile", menuName = "Robot Card")]
public class RobotProfile : ScriptableObject
{
    public Sprite robot;
    public int hp;
    public bool isNext;

}
