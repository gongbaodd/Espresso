using UnityEngine;

[RequireComponent(typeof(JumpController), typeof(GravityController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isDown = true; // is on bottom
    private Animator ani;

    public void JumpAnimation()
    {
        ani.SetBool("jump", true);
        ani.SetBool("runnin", false);
    }

    public void RunAnimation()
    {
        ani.SetBool("jump", false);
        ani.SetBool("runnin", true);
    }

    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
}
