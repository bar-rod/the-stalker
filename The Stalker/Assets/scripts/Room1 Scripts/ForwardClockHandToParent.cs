using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ForwardClockHandToParent : MonoBehaviour,
    IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler
{
    // The object that actually rotates which is the root of the hand
    [SerializeField] private GameObject clockRoot;

    void Awake()
    {
        var g = GetComponent<Graphic>();
        if (g) g.raycastTarget = true;
    }

    /// Forward pointer-down from the hand to the root.
    public void OnPointerDown(PointerEventData e)
    {
        if (clockRoot) ExecuteEvents.Execute(clockRoot, e, ExecuteEvents.pointerDownHandler);
    }

    /// Forward drag events from the hand to the root.
    public void OnDrag(PointerEventData e)
    {
        if (clockRoot) ExecuteEvents.Execute(clockRoot, e, ExecuteEvents.dragHandler);
    }

    /// Forward pointer-up from the hand to the root.
    public void OnPointerUp(PointerEventData e)
    {
        if (clockRoot) ExecuteEvents.Execute(clockRoot, e, ExecuteEvents.pointerUpHandler);
    }

    public void OnPointerEnter(PointerEventData e)
    {
        if (clockRoot) ExecuteEvents.Execute(clockRoot, e, ExecuteEvents.pointerEnterHandler);
    }
}
