using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DraggableClockRoot : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [Header("References")]
    public RectTransform faceRect;
    public Canvas canvas;
    public RectTransform handGraphic;

    [Header("Layout")]
    public float handLength = 100f;
    public float handThickness = 8f;

    [Header("Behavior")]
    public bool snapOnRelease = true;
    public UnityEvent onCorrectTime;

    RectTransform handRoot;
    bool dragging;
    float grabAngleOffsetDegree;

    [SerializeField] private AudioSource _tuningSound;

    void Awake()
    {
        handRoot = (RectTransform)transform;
        if (!faceRect) faceRect = (RectTransform)handRoot.parent;
        EnsureLayout();
    }

    // Size and position the hand root and the graphic
    void EnsureLayout()
    {
        handRoot.pivot = new Vector2(0.5f, 0.5f);
        handRoot.anchorMin = handRoot.anchorMax = new Vector2(0.5f, 0.5f);
        handRoot.anchoredPosition = Vector2.zero;

        if (handGraphic)
        {
            handGraphic.pivot = new Vector2(0.5f, 0.5f);
            handGraphic.anchorMin = handGraphic.anchorMax = new Vector2(0.5f, 0.5f);
            handGraphic.sizeDelta = new Vector2(handThickness, handLength);
            handGraphic.anchoredPosition = new Vector2(0f, handLength * 0.5f);
            handGraphic.localRotation = Quaternion.identity;
            handGraphic.localScale = Vector3.one;
        }
    }

    // Start drag and remember the grab offset so the hand doesn't jump
    public void OnPointerDown(PointerEventData e)
    {
        dragging = true;
        if (ScreenToLocalOnFace(e.position, out var local))
        {
            float pointerAngleFromTop = Mathf.Atan2(local.y, local.x) * Mathf.Rad2Deg - 90f;
            float handAngleFromTop = handRoot.localEulerAngles.z;
            grabAngleOffsetDegree = Mathf.DeltaAngle(pointerAngleFromTop, handAngleFromTop);
        }
        _tuningSound.Play();
    }

    // While dragging, rotate the hand to follow the pointer
    public void OnDrag(PointerEventData e)
    {
        if (!dragging) return;
        if (ScreenToLocalOnFace(e.position, out var local))
        {
            float pointerAngleFromTop = Mathf.Atan2(local.y, local.x) * Mathf.Rad2Deg - 90f;
            float newHandAngle = pointerAngleFromTop + grabAngleOffsetDegree;
            handRoot.localRotation = Quaternion.Euler(0f, 0f, newHandAngle);
        }
        
    }

    // End drag, snap to nearest minute, then fire event for ClockManager to check
    public void OnPointerUp(PointerEventData e)
    {
        if (!dragging) return;
        dragging = false;

        if (snapOnRelease)
        {
            // Snap to nearest minute (every 6°)
            float currentAngle = GetClockwiseAngleFromUp();
            float snappedAngle = Mathf.Round(currentAngle / 6f) * 6f;
            SetZRotationFromClockwise(snappedAngle);
        }

        _tuningSound.Stop();
        // Fire event so ClockManager can check if both hands are correct
        onCorrectTime?.Invoke();
    }

    public void OnPointerEnter(PointerEventData e)
    {
        Debug.Log("OnPointerEnter");
    }
    // Convert a screen point to the clock face local point
    bool ScreenToLocalOnFace(Vector2 screen, out Vector2 local)
    {
        Camera cam = (canvas && canvas.renderMode != RenderMode.ScreenSpaceOverlay) ? canvas.worldCamera : null;
        return RectTransformUtility.ScreenPointToLocalPointInRectangle(faceRect, screen, cam, out local);
    }

    // Read the hand angle clockwise from 12 o'clock in degrees
    float GetClockwiseAngleFromUp()
    {
        float zCounterClockwiseFromUp = handRoot.localEulerAngles.z;
        return Mathf.Repeat(-zCounterClockwiseFromUp, 360f);
    }

    // Set the hand rotation from a clockwise angle in degrees
    void SetZRotationFromClockwise(float clockwiseAngle)
    {
        float counterClockwiseFromUp = -clockwiseAngle;
        handRoot.localRotation = Quaternion.Euler(0f, 0f, counterClockwiseFromUp);
    }

    // Get the minute [0..59] from the current hand angle
    public int GetMinute() => Mathf.RoundToInt(GetClockwiseAngleFromUp() / 6f) % 60;

    // Get the hour [0..11] from the current hand angle (0 = 12 o'clock) - used by ClockManager
    public int GetHour12Rounded() => Mathf.RoundToInt(GetClockwiseAngleFromUp() / 30f) % 12;

    // Get the current angle clockwise from 12 o'clock in degrees
    public float GetClockwiseAngle() => GetClockwiseAngleFromUp();

    // Set the hand angle directly in degrees clockwise from 12 o'clock - used by MinuteDrivesHour
    public void SetFromClockwiseAngle(float clockwiseAngle) => SetZRotationFromClockwise(Mathf.Repeat(clockwiseAngle, 360f));
}