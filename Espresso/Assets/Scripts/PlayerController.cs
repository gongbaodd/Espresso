using UnityEngine;

[RequireComponent(typeof(JumpController), typeof(gravityController))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isDown = true; // is on bottom
}
