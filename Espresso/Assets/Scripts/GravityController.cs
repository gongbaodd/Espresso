using UnityEngine;

public class GravityController : MonoBehaviour
{
    private GameObject manager;
    private bool IsDown {
        get {
            return gameObject.GetComponent<PlayerController>().isDown;
        }
        set {
            gameObject.GetComponent<PlayerController>().isDown = value;
        }
    }

    private float Gravity {
        get {
            return manager.GetComponent<LevelManagerController>().levelConfig.gravity;
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
    }

    void Reverse()
    {
        // isOnFloor = false; // Reset isOnFloor state
        IsDown = !IsDown;
        var gravityFactor = IsDown ? -1f : 1f; // on bottom, gravity down | on top, gravity up
        Physics2D.gravity = new Vector2(0, Gravity * gravityFactor); // Adjust gravity direction

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
