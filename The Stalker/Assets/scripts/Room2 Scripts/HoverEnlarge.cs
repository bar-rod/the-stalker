using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;


public class HoverEnlarge : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Hover Animations")]
    [SerializeField] float scaleFactor = 1.1f;
    [SerializeField] float duration = 0.12f;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = gameObject.transform.localScale;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(ScaleTo(originalScale * scaleFactor));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(ScaleTo(originalScale));
    }
    
    //Scale the button to the target scale
    IEnumerator ScaleTo(Vector3 target)
    {
        Vector3 start = transform.localScale;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float lerp = time / duration;
            transform.localScale = Vector3.Lerp(start, target, lerp);
            yield return null;
        }

        gameObject.transform.localScale = target;
    }
}