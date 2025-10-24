using UnityEngine;
using UnityEngine.InputSystem;

public class ClueBoardCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _ClueBoardCanvas;
    [SerializeField] InputActionAsset inputActions;

    private void Awake()
    {
        _ClueBoardCanvas.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _ClueBoardCanvas.SetActive(true);
        //Debug.Log("Clueboard is being touched");
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
        */

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        _ClueBoardCanvas.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
