using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private int SlotID; // slot 1 has slotid 0, same as indexes in an array
    [SerializeField] private Sprite emptySlotSprite;
    const string emptySlotText = "Empty";


    private Inventory inventory;
    private Item item;
    // Update is called once per frame

    private void Awake()
    {
        inventory = GetComponentInParent<Inventory>();
    }
    private void OnEnable()
    {
        if (inventory == null || inventory.inventoryList.Count == 0 || SlotID < 0 || SlotID >= inventory.inventoryList.Count)
        {
            GetComponentInChildren<Text>().text = emptySlotText;
            GetComponent<Image>().sprite = emptySlotSprite; // empty inventory slot icon needed
        }
        else
        {
            item = inventory.GetItemFromInventory(SlotID);
            if (item != null)
            {
                GetComponentInChildren<Text>().text = item.itemName;
                GetComponent<Image>().sprite = item.itemSprite;
            }
            else
            {
                GetComponentInChildren<Text>().text = emptySlotText;
                GetComponent<Image>().sprite = emptySlotSprite;
            }
        }
    }
}
