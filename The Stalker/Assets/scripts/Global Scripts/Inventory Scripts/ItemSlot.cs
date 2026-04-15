using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private int SlotID; // slot 1 has slotid 0, same as indexes in an array

    public InventoryManager inventory;
    private Item item;
    [SerializeField] private Image icon;
    [SerializeField] private Image highlight;
    public bool hasItem;
    

    private void Update()
    {
        UpdateSlot();
    }
    private void OnEnable()
    {
        UpdateSlot();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hasItem) highlight.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        highlight.gameObject.SetActive(false);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (hasItem)
        {
            Debug.Log(item.name + " was clicked.");
            inventory.UseItem(item);

        }
    }
    private void UpdateSlot()
    {
        if (inventory.GetInventory().Count > SlotID)
        {
            item = inventory.GetInventory()[SlotID];
            icon.sprite = item.itemSpriteInv;
            icon.enabled = true;
            hasItem = true;
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
            hasItem = false;
        }
    }
}
