using UnityEngine;

// Move the Hour hand as the Minute Hand moves
public class MinuteDrivesHour : MonoBehaviour
{
    public DraggableClockRoot minuteHand;
    public DraggableClockRoot hourHand;
    [Range(0,11)] public int baseHour = 0; // hour shown when minutes are 0

    float prevMinuteCW;
    float unwrappedMinuteCW;

    void Start()
    {
        if (minuteHand) prevMinuteCW = minuteHand.GetClockwiseAngle();
        unwrappedMinuteCW = 0f;
    }

    // update the hour hand, angle doesn't reset every full 360 rotation
    void LateUpdate()
    {
        if (!minuteHand || !hourHand) return;

        float currCW = minuteHand.GetClockwiseAngle();
        float delta = Mathf.DeltaAngle(prevMinuteCW, currCW);
        unwrappedMinuteCW += delta;
        prevMinuteCW = currCW;

        float totalMinutes = unwrappedMinuteCW / 6f; // 6° per minute
        float hourCW = baseHour * 30f + totalMinutes * 0.5f;  // 0.5° per minute on hour hand

        // Set the hour hand angle directly in degrees 0° = 12 o'clock
        hourHand.SetFromClockwiseAngle(hourCW);
    }
}
