using UnityEngine;

[RequireComponent(typeof(JumpController), typeof(GravityController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isDown = true;
    public event System.Action<bool> OnGravityChanged;
    private Animator ani;

    public void JumpAnimation()
    {
        ani.SetBool("jump", true);
        ani.SetBool("runnin", false);
        ani.SetBool("hop", false);
    }

    public void RunAnimation()
    {
        ani.SetBool("jump", false);
        ani.SetBool("runnin", true);
        ani.SetBool("hop", false);
    }

    public void hopAnimation()
    {
        ani.SetBool("hop", true);
        ani.SetBool("runnin", false);
        ani.SetBool("jump", false);
    }
    

    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }
}
