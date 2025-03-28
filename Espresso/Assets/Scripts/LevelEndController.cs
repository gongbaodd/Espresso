
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEndController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
       print(other.gameObject.name);
        SceneManager.LoadScene("LevelEnd");
    }
}
