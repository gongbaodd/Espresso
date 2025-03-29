using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig", order = 1)]
public class LevelConfig : ScriptableObject
{
    public float runningSpeed = 2f;
    public float jumpForce = 5f;
    public float gravity = 9.81f; // Default gravity value

    public float temperatureUpdateInterval = .5f; // Interval in seconds for temperature updates
}
