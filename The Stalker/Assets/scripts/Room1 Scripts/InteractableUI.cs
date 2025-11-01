using System.Collections.Generic;
using UnityEngine;

public class InteractableUI : MonoBehaviour
{
    private struct CanvasName{
        string name;
        GameObject theCanvas;
    };
    [SerializeField] private List<CanvasName> interactableUIs;
    
    
}