
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    [SerializeField] private string levelName = "LevelMenu";
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName, LoadSceneMode.Single);
        }
    }
}
