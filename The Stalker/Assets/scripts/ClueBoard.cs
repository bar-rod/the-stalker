using UnityEngine;
using UnityEngine.EventSystems;

public class PaperClueBoard : MonoBehaviour,
IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("onDrag");
        //When an item gets dragged, it moves along with the mouse to the scale of the canvas screen
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
        
    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
    }

    

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
       // Debug.Log("OnPointerDown");
    }
}
