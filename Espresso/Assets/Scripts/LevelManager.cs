using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GameManager : MonoBehaviour
{
    public GameObject background;
    public float backgroundSpeed = 2f;
    public Transform player;
    public float jumpForce = 5f;
    public float dashSpeed = 10f;

    private Rigidbody2D playerRb;
    private bool isOnFloor = true;
    private bool isOnBottom = true;


    void MoveBackground()
    {
        background.transform.position += Vector3.left * backgroundSpeed * Time.deltaTime;
    }

    void GroundTest() {
        var gravityFactor = isOnBottom ? -1f : 1f; // on bottom, point down | on top, point up

        RaycastHit2D hit = Physics2D.Raycast(player.position, Vector2.up * gravityFactor, 1f);
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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Reverse();
        }
    }

    void Jump()
    {
        var gravityFactor = isOnBottom ? -1f : 1f; // on bottom, jump up | on top, jump down
        if (isOnFloor)
        {
            print("Jumping");
            playerRb.velocity = new Vector2(playerRb.velocity.x, -jumpForce * gravityFactor);

            print("Jumping with gravity factor: " + -jumpForce * gravityFactor);
            print(isOnBottom);
            isOnFloor = false;
        }
    }

    void Reverse()
    {
        isOnFloor = false; // Reset isOnFloor state

        isOnBottom = !isOnBottom; // Toggle the isOnBottom state
        var gravityFactor = isOnBottom ? -1f : 1f; // on bottom, gravity down | on top, gravity up

        Physics2D.gravity = new Vector2(0, -9.81f * gravityFactor); // Adjust gravity direction
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
