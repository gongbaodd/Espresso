using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LevelMenuController : MonoBehaviour
{
    private UIDocument uiDocument;
    private Button level1Button;
    private Button level2Button;
    private Button level3Button;

    void OnEnable()
    {
        uiDocument = GetComponent<UIDocument>();
        level1Button = uiDocument.rootVisualElement.Q<Button>("Level1Button");
        level2Button = uiDocument.rootVisualElement.Q<Button>("Level2Button");
        level3Button = uiDocument.rootVisualElement.Q<Button>("Level3Button");

        level1Button.RegisterCallback<ClickEvent>(ev => LoadLevel("Level"));
        // TODO:
        // level2Button.RegisterCallback<ClickEvent>(ev => LoadLevel("Level2"));
        // level3Button.RegisterCallback<ClickEvent>(ev => LoadLevel("Level3"));
    }

    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

}
