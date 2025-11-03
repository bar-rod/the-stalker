using UnityEngine;
using UnityEngine.Events;

public class ClockManager : MonoBehaviour
{
    [Header("Hand References")]
    public DraggableClockRoot minuteHand;
    public DraggableClockRoot hourHand;

    [Header("Target Time")]
    [Range(0, 59)] public int targetMinute = 0;
    [Range(0, 11)] public int targetHour = 0;  // 0 = 12 o'clock

    [Header("Tolerance")]
    [Range(0f, 15f)] public float hitToleranceDegrees = 6f;

    [Header("Events")]
    public UnityEvent onBothHandsCorrect;


    // Subscribe to both hands' release events
    void Start()
    {
        if (minuteHand) minuteHand.onCorrectTime.AddListener(CheckBothHands);
        if (hourHand) hourHand.onCorrectTime.AddListener(CheckBothHands);
        
        Debug.Log($"ClockManager: Target time is {targetHour}:{targetMinute:D2}");
    }

    // Called whenever either hand is released
    void CheckBothHands()
    {
        if (!minuteHand || !hourHand) return;

        int currentMinute = minuteHand.GetMinute();
        int currentHour = hourHand.GetHour12Rounded();
        
        Debug.Log($"Current time: {currentHour}:{currentMinute:D2} | Target: {targetHour}:{targetMinute:D2}");

        if (AreBothHandsCorrect())
        {
            Debug.Log("Correct, Both hands are in position");
            onBothHandsCorrect?.Invoke();
        }
        else
        {
            // Show what's wrong
            float minuteAngle = minuteHand.GetClockwiseAngle();
            float targetMinuteAngle = targetMinute * 6f;
            float minuteDelta = Mathf.Abs(Mathf.DeltaAngle(minuteAngle, targetMinuteAngle));

            float hourAngle = hourHand.GetClockwiseAngle();
            // Hour hand should be at: (hour * 30°) + (minute * 0.5°)
            float targetHourAngle = targetHour * 30f + targetMinute * 0.5f;
            float hourDelta = Mathf.Abs(Mathf.DeltaAngle(hourAngle, targetHourAngle));

            Debug.Log($"Not correct. Minute off by {minuteDelta:F1}°, Hour off by {hourDelta:F1}° (tolerance: {hitToleranceDegrees}°)");
        }
    }

    // Check if both hands are within tolerance of target time
    bool AreBothHandsCorrect()
    {
        if (!minuteHand || !hourHand) return false;

        // Check minute hand
        float minuteAngle = minuteHand.GetClockwiseAngle();
        float targetMinuteAngle = targetMinute * 6f;
        float minuteDelta = Mathf.Abs(Mathf.DeltaAngle(minuteAngle, targetMinuteAngle));

        // Check hour hand
        float hourAngle = hourHand.GetClockwiseAngle();
        // Each hour is 30°, plus the hour hand moves 0.5° per minute
        float targetHourAngle = targetHour * 30f + targetMinute * 0.5f;
        float hourDelta = Mathf.Abs(Mathf.DeltaAngle(hourAngle, targetHourAngle));

        return minuteDelta <= hitToleranceDegrees && hourDelta <= hitToleranceDegrees;
    }


    public void PrintSmth()
    {
        Debug.Log("Event Fired");
    }
}
