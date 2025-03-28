using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackController : MonoBehaviour
{
    private GameObject manager;
    private LevelConfig Config {
        get
        {
            return manager.GetComponent<LevelManagerController>().levelConfig;
        }
    }

    private float runningSpeed;
    void Start()
    {
        manager = GameObject.Find("Manager");
        if (manager == null)
        {
            throw new System.Exception("Manager object not found in the scene.");
        }

        runningSpeed = Config.runningSpeed;
    }
    void Update()
    {
        transform.position += Vector3.left * runningSpeed * Time.deltaTime;
    }
}
