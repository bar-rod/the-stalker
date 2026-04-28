using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class MusicBoxCrank : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private GameObject MusicBoxPanel;
    private RectTransform rectTransform;
    private float lastAngle;

    [SerializeField] private List<float> combination = new List<float>(); // target angles in sequence
    [SerializeField] private float tolerance = 5f; // how close you need to be to target angle

    private int currentStage = 0;
    private bool isSolved = false;

    public float totalDegrees { get; private set; } = 0f;
    public float currentAngle => rectTransform.eulerAngles.z;
    public int fullRotations => Mathf.FloorToInt(Mathf.Abs(totalDegrees) / 360f);

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData e)
    {
        lastAngle = GetPointerAngle(e);
    }

    public void OnDrag(PointerEventData e)
    {
        if (isSolved) return;

        float current = GetPointerAngle(e);
        float delta = Mathf.DeltaAngle(lastAngle, current);

        totalDegrees += delta;
        rectTransform.Rotate(0f, 0f, delta);
        lastAngle = current;
    }

    public void OnPointerUp(PointerEventData e)
    {
        if (isSolved) return;

        float target = combination[currentStage];
        float diff = Mathf.Abs(Mathf.DeltaAngle(currentAngle, target));

        if (diff <= tolerance)
        {
            currentStage++;
            Debug.Log($"Stage {currentStage} complete!");
            rectTransform.localEulerAngles = new Vector3(0, 0, target);
            // play a "correct" click sound

            if (currentStage >= combination.Count)
            {
                isSolved = true;
                Debug.Log("Solved!");
                OnSolved();
            }
        }
        else
        {
            Debug.Log($"Wrong angle ({currentAngle:F1}), needed {target}. Resetting.");
            // play an "incorrect" click sound
            rectTransform.localEulerAngles = new Vector3(0, 0, 0);
            currentStage = 0;
        }

        ResetTracking();
    }

    void OnSolved()
    {
        MusicBoxPanel.SetActive(false);
        // idk what the logic on this will be rn
    }

    float GetPointerAngle(PointerEventData e)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            e.position, e.pressEventCamera, out Vector2 localPoint
        );
        Vector2 dir = localPoint - rectTransform.anchoredPosition;
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    public void ResetTracking()
    {
        totalDegrees = 0f;
    }

    public void ClosePanel()
    {
        MusicBoxPanel.SetActive(false);
        Debug.Log("close musiuc box panel");
    }
}