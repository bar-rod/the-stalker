using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LicensePlate : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField] private Image keyImage;
    [SerializeField] private Sprite keyOg;
    [SerializeField] private Sprite keyOutline;

    [SerializeField] private GameObject popUp;

    public void Start()
    {
        popUp.SetActive(false);
    }
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

    public void OnPointerDown(PointerEventData eventData)
    {
        popUp.SetActive(true);
    }
    public void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            popUp.SetActive(false);
        }
    }
}
