using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "ScriptableObjects/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    public float runningSpeed = 2f;
    public float jumpForce = 5f;

    public float gravity = 9.81f; // Default gravity value
}
