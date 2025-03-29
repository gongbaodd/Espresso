using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
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
    public bool isOnFloor
    {
        get { return GroundTest(); }

    }
    private float gravityFactor
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

        if (isOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -jumpForce * gravityFactor);
            playerController.JumpAnimation();
        }
    }

    bool GroundTest()
    {
        if (transform.position.y > 3f)
        {
            //TODO: hit test can not find ceiling, hardcode instead
            return true;
        }
        var hitY = 5 * gravityFactor * Vector2.up;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, hitY, 1f);

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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (isOnFloor) {
            var playerController = gameObject.GetComponent<PlayerController>();
            playerController.RunAnimation();
        }
        
        var hitY = 5 * gravityFactor * Vector2.up;
        Debug.DrawRay(transform.position, hitY, Color.red);
    }
}
