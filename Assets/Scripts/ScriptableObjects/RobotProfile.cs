using UnityEngine;

[CreateAssetMenu(fileName = "Robot Profile", menuName = "Robot Card")]

public class RobotProfile : ScriptableObject
{
    [Range(50f, 100f)]
    public float hp;

    public Heart heart;

    public Sprite robot;
    public bool isNext;

}
