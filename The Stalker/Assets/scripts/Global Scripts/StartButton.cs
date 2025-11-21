using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button button;
    [SerializeField] private GameObject start;
    [SerializeField] private GameObject reply;
    [SerializeField] private GameObject replyHigh;

    public bool off = false;
    
    void Start()
    {
        button.onClick.AddListener(OpenScene);
    }
    public void OpenScene()
    {
        Debug.Log("Reached");
        off = true;
        start.SetActive(false);
        reply.SetActive(false);
        replyHigh.SetActive(false);
        //SceneManager.LoadScene(1); 
    }

    
}
