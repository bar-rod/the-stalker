using System;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

// If this throws errors, something is null

// Makes toggle invisible when not clicked, and visible when clicked
public class BookShelf : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public UnityEngine.UI.Toggle toggle;
    [SerializeField] public Boolean isSolutionBook = false;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // assign canvasGroup and toggle if not assigned in inspector
        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
        
        if (toggle == null)
            toggle = GetComponent<UnityEngine.UI.Toggle>();

        canvasGroup.alpha = 0f;

        toggle.onValueChanged.AddListener(OnToggleValueChanged);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This highlights the book
    private void OnToggleValueChanged(bool isOn)
    {
        canvasGroup.alpha = isOn ? 0.02f : 0f;
    }
};
