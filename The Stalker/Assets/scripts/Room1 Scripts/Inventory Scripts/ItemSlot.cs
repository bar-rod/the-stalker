using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private int SlotID;
    [SerializeField] private Sprite emptySlotSprite;

    private Item item;
    // Update is called once per frame

    private void OnEnable()
    {
        if (SlotID - 1 < 0 || SlotID - 1 > GetComponentInParent<Inventory>().inventoryList.Count)
        {
            GetComponentInChildren<Text>().text = "Empty";
            GetComponent<Image>().sprite = emptySlotSprite; // empty inventory slot icon needed
        }
        else
        {
            item = GetComponentInParent<Inventory>().GetItemFromInventory(SlotID);
            GetComponentInChildren<Text>().text = item.itemName;
            GetComponent<Image>().sprite = item.itemSprite;
        }
    }
}
