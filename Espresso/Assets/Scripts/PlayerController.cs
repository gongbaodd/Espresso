using UnityEngine;

[RequireComponent(typeof(JumpController), typeof(GravityController))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isDown = true; // is on bottom
}
