using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void LoadScene(string _sceneName)
    {
        Debug.Log("Loading scene " + _sceneName);
        SceneManager.LoadScene(_sceneName);
    }
}
