using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackController : MonoBehaviour
{
    [SerializeField] GameObject manager;

    private float runningSpeed;
    void OnEnable()
    {
        runningSpeed = manager.GetComponent<GameManager>().runningSpeed;
    }
    void Update()
    {
        transform.position += Vector3.left * runningSpeed * Time.deltaTime;
    }
}
