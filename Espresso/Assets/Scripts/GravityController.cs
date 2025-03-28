using UnityEngine;

public class gravityController : MonoBehaviour
{
    private bool isDown {
        get {
            return gameObject.GetComponent<PlayerController>().isDown;
        }
        set {
            gameObject.GetComponent<PlayerController>().isDown = value;
        }
    }

    private float gravity = 9.81f; // Default gravity value

    void Reverse()
    {
        // isOnFloor = false; // Reset isOnFloor state
        isDown = !isDown;
        var gravityFactor = isDown ? -1f : 1f; // on bottom, gravity down | on top, gravity up
        Physics2D.gravity = new Vector2(0, gravity * gravityFactor); // Adjust gravity direction

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Reverse();
            var ani = gameObject.GetComponent<Animator>();
            ani.SetBool("jump", true);
            ani.SetBool("runnin", false);
        }
    }
}
