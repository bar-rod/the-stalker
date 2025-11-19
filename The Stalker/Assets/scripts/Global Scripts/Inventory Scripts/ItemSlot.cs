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
    [SerializeField] private TextMeshProUGUI text;
    public bool hasItem;

    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        UpdateSlot();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hasItem)
            TooltipManager._instance.SetAndShowTooltip(item.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager._instance.HideTooltip();
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
            icon.sprite = item.itemSprite;
            icon.enabled = true;
            text.text = item.name;
            hasItem = true;
        }
        else
        {
            icon.sprite = null;
            icon.enabled = false;
            text.text = "";
            hasItem = false;
        }
    }
}
