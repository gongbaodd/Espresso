using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GameManager : MonoBehaviour
{
    public GameObject background;
    public GameObject ending;
    public float runningSpeed = 2f;
    public GameObject player;
    public float jumpForce = 5f;
    public float dashSpeed = 10f;

    private Rigidbody2D playerRb;
    private bool isOnFloor = true;
    private bool isOnBottom = true;


    void MoveBackground()
    {
    }

    void GroundTest()
    {
        var gravityFactor = isOnBottom ? -1f : 1f; // on bottom, point down | on top, point up

        RaycastHit2D hit = Physics2D.Raycast(player.transform.position, Vector2.up * gravityFactor, 0.1f);
        Debug.DrawRay(player.transform.position, Vector2.up * gravityFactor, Color.red, 0.1f); // Visualize the raycast

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
            var ani = player.GetComponent<Animator>();
            ani.SetBool("jump", true);
            ani.SetBool("runnin", false);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Reverse();
            var ani = player.GetComponent<Animator>();
            ani.SetBool("jump", true);
            ani.SetBool("runnin", false);
        }
    }

    void Jump()
    {
        var gravityFactor = isOnBottom ? -1f : 1f; // on bottom, jump up | on top, jump down
        if (isOnFloor)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, -jumpForce * gravityFactor);
            isOnFloor = false;
        }
    }

    void Reverse()
    {
        isOnFloor = false; // Reset isOnFloor state
        isOnBottom = !isOnBottom;

        var gravityFactor = isOnBottom ? -1f : 1f; // on bottom, gravity down | on top, gravity up
        Physics2D.gravity = new Vector2(0, 9.81f * gravityFactor); // Adjust gravity direction

    }

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
}
