
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    [SerializeField] private string levelName = "Level_with_stuff";
    [SerializeField] private string levelEnd = "LevelEnd";
    void OnTriggerEnter2D(Collider2D collision)
    {
        print("Collision detected with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == levelName)
            {
                SceneManager.LoadScene(levelEnd, LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene(levelName, LoadSceneMode.Single);
            }
        }
    }
}
