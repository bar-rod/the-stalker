using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private int SlotID; // slot 1 has slotid 0, same as indexes in an array
    [SerializeField] private Sprite emptySlotSprite; // empty inventory slot icon needed
    private bool hasItem;

    const string emptySlotText = "Empty";

    private Inventory inventory;
    private Item item;

    private void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
    }
    private void OnEnable()
    {
        if (inventory == null || inventory.inventoryList.Count == 0 || SlotID < 0 || SlotID >= inventory.inventoryList.Count)
        {
            GetComponentInChildren<TMP_Text>().text = emptySlotText;
            GetComponent<Image>().sprite = emptySlotSprite;
            hasItem = false;
        }
        else
        {
            item = inventory.GetItemFromInventory(SlotID);
            if (item != null)
            {
                GetComponentInChildren<TMP_Text>().text = item.itemName;
                GetComponent<Image>().sprite = item.itemSprite;
                hasItem = true;
            }
            else
            {
                GetComponentInChildren<TMP_Text>().text = emptySlotText;
                GetComponent<Image>().sprite = emptySlotSprite;
                hasItem = false;
            }
        }
    }
    //private void OnMouseEnter()
    //{
    //    if (hasItem)
    //        TooltipManager._instance.SetAndShowTooltip(item.description);
    //}

    //private void OnMouseExit()
    //{
    //    TooltipManager._instance.HideTooltip();
    //}


    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hasItem)
            TooltipManager._instance.SetAndShowTooltip(item.description);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager._instance.HideTooltip();
    }
}
