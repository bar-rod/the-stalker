using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button button;
    
    void Start()
    {
        button.onClick.AddListener(OpenScene);
    }
    public void OpenScene()
    {
        Debug.Log("Reached");
        SceneManager.LoadScene(1); 
    }

    
}
