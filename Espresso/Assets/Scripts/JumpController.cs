using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpController : MonoBehaviour
{
    private GameObject manager;
    private Rigidbody2D playerRb;

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
    private bool isOnFloor
    {
        get { return GroundTest(); }

    }
    void Jump()
    {
        var gravityFactor = IsDown ? -1f : 1f; // on bottom, jump up | on top, jump down
        var jumpForce = Config.jumpForce;

        if (isOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -jumpForce * gravityFactor);
        }
    }

    bool GroundTest()
    {
        var gravityFactor = IsDown ? -1f : 1f; // on bottom, point down | on top, point up

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up * gravityFactor, 0.1f);
        Debug.DrawRay(transform.position, Vector2.up * gravityFactor, Color.red, 0.1f); // Visualize the raycast

        if (hit.collider != null)
        {
            return true;

        }
        else
        {
            return false;
        }
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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            var ani = gameObject.GetComponent<Animator>();
            ani.SetBool("jump", true);
            ani.SetBool("runnin", false);
        }
    }
}
