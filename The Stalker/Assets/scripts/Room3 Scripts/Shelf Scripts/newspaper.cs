using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.InputSystem;

public class newspaper : MonoBehaviour
{
    [SerializeField] private GameObject parentCanvas;

    public void onClick()
    {
        this.gameObject.SetActive(true);
        parentCanvas.SetActive(false);
    }

    public void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        // Close this canvas when E is pressed
        if (Keyboard.current.eKey.wasPressedThisFrame && this.gameObject.activeSelf)  // why does this not work???
        {
            parentCanvas.SetActive(true);
            this.gameObject.SetActive(false);


        }
    }
}
