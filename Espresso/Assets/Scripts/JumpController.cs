using UnityEngine;
using UnityEngine.Timeline;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class JumpController : MonoBehaviour
{
    private GameObject manager;
    private Rigidbody2D playerRb;
    public Audio_Manager audioManager;

    private LevelConfig Config
    {
        get
        {
            return manager.GetComponent<LevelManagerController>().levelConfig;
        }
    }
    private bool IsDown
    {
        get
        {
            return gameObject.GetComponent<PlayerController>().isDown;
        }
    }
    public bool IsOnFloor
    {
        get { return GroundTest(); }

    }
    private float GravityFactor
    {
        get
        {
            return IsDown ? -1f : 1f; // on bottom, point down | on top, point up
        }
    }
    void Jump()
    {
        var jumpForce = Config.jumpForce;
        var playerController = gameObject.GetComponent<PlayerController>();


        if (IsOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -jumpForce * GravityFactor);
            playerController.hopAnimation();
        }
    }

    bool GroundTest()
    {

        var hitY = 5 * GravityFactor * Vector2.up;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, hitY, 5f);
        Debug.DrawRay(transform.position, hitY, Color.red);


        if (hit.collider == null)
        {
            return false;
        }

        if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Ceiling"))
        {
            return true;

        }

        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        manager = GameObject.Find("Manager");
        if (manager == null)
        {
            throw new System.Exception("Manager object not found in the scene.");
        }

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<Audio_Manager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (IsOnFloor) {
            var playerController = gameObject.GetComponent<PlayerController>();
            playerController.RunAnimation();
            
        }
    }
}
