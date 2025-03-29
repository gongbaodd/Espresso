using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class TemperatureController : MonoBehaviour
{
    public float currentTemperature = 50f;

    private GameObject player;

    private GameObject manager;

    private ProgressBar progressBar;

    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        progressBar = uiDocument.rootVisualElement.Q<ProgressBar>("ProgressBar");

        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            throw new System.Exception("Player GameObject not found. Make sure it has the 'Player' tag.");
        }

        manager = GameObject.FindGameObjectWithTag("Manager");

        if (manager == null)
        {
            throw new System.Exception("Manager GameObject not found. Make sure it has the 'Manager' tag.");
        }

        StartCoroutine(UpdateTemperature());

    }


    IEnumerator UpdateTemperature()
    {
        var playerController = player.GetComponent<PlayerController>();
        var interval = manager.GetComponent<LevelManagerController>().levelConfig.temperatureUpdateInterval;

        while(true) {
            yield return new WaitForSeconds(interval);
            if (playerController.isDown && currentTemperature < 100f)
            {
                currentTemperature += 1f;
                progressBar.value = currentTemperature;
            }
            else if (!playerController.isDown && currentTemperature > 0f)
            {
                currentTemperature -= 1f;
                progressBar.value = currentTemperature;
            }
        }
    }
}
