using UnityEngine;
using UnityEngine.SceneManagement;

public class StartRoom1 : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
