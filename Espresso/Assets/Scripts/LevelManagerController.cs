using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerController : MonoBehaviour
{
    public LevelConfig levelConfig;

    void Start()
    {
        if (levelConfig == null)
        {
            throw new System.Exception("LevelConfig is not assigned in the inspector.");
        }
    }
}
