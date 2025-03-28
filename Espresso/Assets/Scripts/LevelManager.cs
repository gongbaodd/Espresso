using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject background;
    public float backgroundSpeed = 2f;
    public Transform player;
    public float jumpForce = 5f;
    public float dashSpeed = 10f;
    public float dashCooldown = 1f;

    private Rigidbody2D playerRb;
    private bool canDash = true;
    private bool isOnFloor = true;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveBackground();
        HandleInput();
        GroundTest();
    }

    void MoveBackground()
    {
        background.transform.position += Vector3.left * backgroundSpeed * Time.deltaTime;
    }

    void GroundTest() {
        RaycastHit2D hit = Physics2D.Raycast(player.position, Vector2.down, 1f);
        if (hit.collider != null)
        {
            isOnFloor = true;
        }
        else
        {
            isOnFloor = false;
        }
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            Dash();
        }
    }

    void Jump()
    {
        if (isOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isOnFloor = false;
        }
    }

    void Dash()
    {
        canDash = false;
        isOnFloor = !isOnFloor; // Toggle between floor and ceiling
        float targetY = isOnFloor ? -3f : 3f; // Set floor and ceiling height

        Physics2D.gravity = new Vector2(0, 9.81f); 
        StartCoroutine(DashMovement(targetY));
        StartCoroutine(DashCooldown());
    }

    IEnumerator DashMovement(float targetY)
    {
        float elapsedTime = 0f;
        Vector2 startPos = player.position;
        Vector2 targetPos = new Vector2(startPos.x, targetY);

        while (elapsedTime < 0.2f)
        {
            player.position = Vector2.Lerp(startPos, targetPos, (elapsedTime / 0.2f));
            elapsedTime += Time.deltaTime * dashSpeed;
            yield return null;
        }

        player.position = targetPos;
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
