using UnityEngine;
using UnityEngine.UI;

public class xButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject clock;
    [SerializeField] private Button button;

    void Start()
    {
        button.onClick.AddListener(Close);
    }
    
    public void Close()
    {
        clock.SetActive(false);
    }
}
