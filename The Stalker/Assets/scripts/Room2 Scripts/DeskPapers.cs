using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeskPapers : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Root Canvas containing the desk")]
    [SerializeField] Canvas canvas;

    [Header("Details page")]
    public GameObject details;
    private Image image;
    private RectTransform clue;

    private bool isDragging = false;
    private void Start()
    {
        clue = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
        clue.anchoredPosition += eventData.delta / canvas.scaleFactor;
        Debug.Log("Is dragging");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging is true)
        {
            isDragging = false;
            image.color = Color.white;
            return;
        }

        image.color = Color.white;
        details.SetActive(true);
        
        Debug.Log("Mouse click let go");
    }

    public void OnPointerDown(PointerEventData eventdata)
    {
        Debug.Log("Mouse click down");
        image.color = Color.black;
    }

    public void OpenClue()
    {
        details.SetActive(true);
        image.enabled = false;
        image.raycastTarget = false;
    }
    
    public void CloseClue()
    {
        details.SetActive(false);
        image.enabled = true;
        image.raycastTarget = true;
    }

}
