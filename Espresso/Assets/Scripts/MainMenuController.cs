using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuController : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button newGameButton;

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        newGameButton = uiDocument.rootVisualElement.Q<Button>("NewGameButton");

        newGameButton.RegisterCallback<ClickEvent>(ev =>
        {
            SceneManager.LoadScene("Level", LoadSceneMode.Single);
        });
    }
}
