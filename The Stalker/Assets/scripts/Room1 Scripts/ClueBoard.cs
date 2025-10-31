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
        randomizeCluePos();
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

    // TODO: Add rotation randomization
    void randomizeCluePos()
    {
        GameObject[] clues = GameObject.FindGameObjectsWithTag("Clue");
        Debug.Log("Found " + clues.Length + " clues to position.");
        foreach (GameObject clue in clues)
        {
            float minimumDistance = (float) 1.5 * clues[0].GetComponent<RectTransform>().rect.width;

            // create a min and max range for x and y positions based on the parent canvas size
            // TODO: Remove magic numbers
            float minX = rectTransform.rect.min.x - 100f;
            float maxX = rectTransform.rect.max.x + 100f;
            float minY = rectTransform.rect.min.y - 50f;
            float maxY = rectTransform.rect.max.y + 50f;
            Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            // first clue can be placed anywhere
            if (clue == clues[0])
                clue.GetComponent<RectTransform>().anchoredPosition = randomPosition;
            else
            {
                // TODO: implement logic to ensure clues are not overlapping here
                clue.GetComponent<RectTransform>().anchoredPosition = randomPosition;
            }
        }
    }
}
