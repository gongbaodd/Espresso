using System.Collections;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private GameObject manager;

    private SpriteRenderer sprite;
    private bool IsDown
    {
        get
        {
            return gameObject.GetComponent<PlayerController>().isDown;
        }
        set
        {
            gameObject.GetComponent<PlayerController>().isDown = value;
        }
    }

    private float Gravity
    {
        get
        {
            return manager.GetComponent<LevelManagerController>().levelConfig.gravity;
        }
    }

    private bool IsOnFloor
    {
        get
        {
            return gameObject.GetComponent<JumpController>().IsOnFloor;
        }
    }

    void Start()
    {
        // Initialize gravity if needed
        manager = GameObject.Find("Manager");
        if (manager == null)
        {
            throw new System.Exception("Manager object not found in the scene.");
        }

        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Reverse()
    {
        IsDown = !IsDown;
        var gravityFactor = IsDown ? -1f : 1f; // on bottom, gravity down | on top, gravity up
        Physics2D.gravity = new Vector2(0, Gravity * gravityFactor); // Adjust gravity direction
        StartCoroutine(FlipSprite()); // Start the coroutine to flip the sprite

        var playerController = gameObject.GetComponent<PlayerController>();
        // TODO: Jump Animation did not triggered when falling
        playerController.JumpAnimation(); // Trigger jump animation

    }

    IEnumerator FlipSprite()
    {
        yield return new WaitForSeconds(.5f); // Wait for a short duration before flipping the sprite
        sprite.flipY = !sprite.flipY; // Flip the sprite
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reverse();
        }

        if (IsOnFloor) {
            var playerController = gameObject.GetComponent<PlayerController>();
            playerController.RunAnimation(); // Trigger run animation when on the floor
        }
    }
}
