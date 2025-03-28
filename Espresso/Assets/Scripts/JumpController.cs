using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpController : MonoBehaviour
{
    public GameObject gameManager;
    private bool isDown {
        get {
            return gameObject.GetComponent<PlayerController>().isDown;
        }
    }

    private Rigidbody2D playerRb;
    private bool isOnFloor
    {
        get { return GroundTest(); }

    }
    void Jump()
    {
        var gravityFactor = isDown ? -1f : 1f; // on bottom, jump up | on top, jump down
        var jumpForce = gameManager.GetComponent<GameManager>().jumpForce;

        if (isOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -jumpForce * gravityFactor);
        }
    }

    bool GroundTest()
    {
        var gravityFactor = isDown ? -1f : 1f; // on bottom, point down | on top, point up

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
