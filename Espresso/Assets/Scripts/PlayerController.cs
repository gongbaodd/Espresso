using UnityEngine;

[RequireComponent(typeof(JumpController), typeof(GravityController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public bool isDown = true;
    public event System.Action<bool> OnGravityChanged;
    private Animator ani;
    public Audio_Manager audioManager;

    public void JumpAnimation()
    {
        ani.SetBool("jump", true);
        ani.SetBool("runnin", false);
        ani.SetBool("hop", false);
    }

    public void JumpSound()
    {
        audioManager.PlaySFX(audioManager.espresso_jump);
    }

    public void RunAnimation()
    {
        ani.SetBool("jump", false);
        ani.SetBool("runnin", true);
        ani.SetBool("hop", false);
    }

    public void RunSound()
    {
        audioManager.PlaySFX(audioManager.espresso_runReverse);
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
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();

    }
}
