using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeskPapers : MonoBehaviour, IPointerUpHandler, IDragHandler, IPointerDownHandler
{
    [Header("Name of the Paper")] 
    [SerializeField] private String name;
    [Header("Root Canvas containing the desk")]
    [SerializeField] Canvas canvas;
    
    [Header("Desk Bounds")]
    [SerializeField] private PolygonCollider2D deskBoundsCollider;
    
    [Header("Details page")]
    public GameObject details;
    
    [Header("Desk Manager")]
    [SerializeField] private ClueOpenManager clueOpenManager;
    private Image image;
    private RectTransform clue;

    private bool isDragging = false;
    private Vector2 lastValidPosition;
    
    protected virtual void Start()
    {
        clue = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        lastValidPosition = clue.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;
    
        Vector2 newPosition = clue.anchoredPosition + eventData.delta / canvas.scaleFactor;
    
        // Always update position during drag
        clue.anchoredPosition = newPosition;
    
        // Check if we're out of bounds
        if (IsPositionInDeskBounds(newPosition))
        {
            lastValidPosition = newPosition;
        }
        else
        {
            // If out of bounds, snap back to last valid position
            clue.anchoredPosition = lastValidPosition;
        }
    
        Debug.Log("Is dragging");
    }
    
    protected bool IsPositionInDeskBounds(Vector2 anchoredPos)
    {
        if (deskBoundsCollider == null)
            return true;
    
        // Temporarily set position to test it
        Vector2 originalPos = clue.anchoredPosition;
        clue.anchoredPosition = anchoredPos;
    
        Vector3 worldPos = clue.TransformPoint(Vector3.zero);
        bool isInBounds = deskBoundsCollider.OverlapPoint(worldPos);
    
        // Restore original position
        clue.anchoredPosition = originalPos;
    
        return isInBounds;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging is true)
        {
            isDragging = false;
            image.color /= 0.7f;
            return;
        }

        image.color = Color.white;
        OpenClue();
        // if (this.name == "Calendar")
        // {
        //     LocatorDialogue2.Instance.Dialogue2Script.ShowElisaText("Oh…that's my birthday.", 0);
        // }
        // else if (this.name == "ResignationLetter")
        // {
        //     LocatorDialogue2.Instance.Dialogue2Script.ShowElisaText("A resignation letter?", 1);
        // }
        
        Debug.Log("Mouse click let go");
    }

    public virtual void OnPointerDown(PointerEventData eventdata)
    {
        Debug.Log("Mouse click down");
        image.color *= 0.7f;
    }

    public void OpenClue()
    {
        details.SetActive(true);
        image.enabled = false;
        image.raycastTarget = false;
        Debug.Log("OpenClue Called");
        clueOpenManager.DisableOtherPaperRaycastTarget(name);

        if (this.name == "Calendar"  && !LocatorDialogue2.Instance.Dialogue2Script.ElisaAudioPlaying)
        {
            LocatorDialogue2.Instance.Dialogue2Script.ShowElisaText("Oh…that's my birthday.", 0);
        }
        else if (this.name == "ResignationLetter"  && !LocatorDialogue2.Instance.Dialogue2Script.ElisaAudioPlaying)
        {
            LocatorDialogue2.Instance.Dialogue2Script.ShowElisaText("A resignation letter?", 1);
        }
    }
    
    public void CloseClue()
    {
        details.SetActive(false);
        image.enabled = true;
        image.raycastTarget = true;
        clueOpenManager.EnableAllPaperRaycastTarget();
    }
}