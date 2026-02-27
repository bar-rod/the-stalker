using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShelfItems : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image keyImage;
    [SerializeField] private Sprite keyOg;
    [SerializeField] private Sprite keyOutline;

    public void OnPointerEnter(PointerEventData eventData)
    {
        keyImage.sprite = keyOutline;
        Debug.Log("Mouse is over key");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        keyImage.sprite = keyOg;
        Debug.Log("Mouse is not over key");
    }
}
