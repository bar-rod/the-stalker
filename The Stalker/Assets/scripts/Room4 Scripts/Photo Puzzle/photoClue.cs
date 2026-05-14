// This script defines behavior for the clues/photos

// NOTE: We might need to refactor the transform if we
// want this to have a false 3d persepective like in
// the art. 

using UnityEngine;
using UnityEngine.EventSystems;

public class photoClue : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public int clueID;  // This determines the correct order!
    [HideInInspector] public ClueSlot currentSlot;  // Parent slot that "owns" this clue.
    private CanvasGroup cg;
    private RectTransform rectTransform;

    private void Awake()
    {
        cg = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = false; 
        cg.alpha = 0.6f; // make the clue semi-transparent ondrag
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        cg.blocksRaycasts = true; 
        cg.alpha = 1f; // delete this if you delete the semi-transparency ondrag

        transform.position = currentSlot.transform.position; // snap back
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
