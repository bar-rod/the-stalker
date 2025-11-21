using System;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine;

public class InteractableUI : MonoBehaviour, Iinteractable
{   
    [Serializable] public struct CanvasUI{
        public string name;
        [Header("Actually doesn't have to be Canvas")]
        public GameObject theCanvas;
    };
    public CanvasUI interactable;
    private bool bCanvasActive;
    IEnumerator Init()
    {
        yield return null;
    }

    private void Start()
    {
        StartCoroutine(Init());
        bCanvasActive = false;
        interactable.theCanvas.SetActive(bCanvasActive);
    }

    public bool Interact()
    {
        if (bCanvasActive)
        {
            CloseUI();
            bCanvasActive = false;
            return false;
        }
        else
        {
            bCanvasActive = true;
            OpenUI();
            return true;
        }
}

    public void CloseUI()
    {
        interactable.theCanvas.SetActive(false);
    }

    public void OpenUI()
    {
        interactable.theCanvas.SetActive(true);

        if (interactable.theCanvas.name == "CanvasClueBoard")
        {
            LocatorDialogue.Instance.DialogueScript.SawClueBoard = true;
        }
    }
}