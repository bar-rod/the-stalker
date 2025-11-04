using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractableUI : MonoBehaviour, Iinteractable
{   
    [Serializable] public struct CanvasUI{
        public string name;
        public GameObject theCanvas;
    };
    public CanvasUI interactable;

    private void Start()
    {
        interactable.theCanvas.SetActive(false);
    }
    public void Interact(Collider2D other)
    {
        if (other == null)
        {
            Debug.Log("Null collider");
            return;
        }
        if (interactable.name == other.name)
        {
            interactable.theCanvas.SetActive(true);
        }
    }

    public void CloseUI(Collider2D other)
    {
        if (other == null)
        {
            Debug.Log("Null collider");
            return;
        }

        if (interactable.name == other.name)
        {
            interactable.theCanvas.SetActive(false);
        }
    }
}