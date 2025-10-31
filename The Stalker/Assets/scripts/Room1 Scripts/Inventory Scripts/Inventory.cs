using UnityEngine;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{

    [SerializeField]
    private Canvas inventoryUI;

    public List<Item> inventoryList = new List<Item>();
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void addItem(Item item)
    {
        inventoryList.Add(item);
    }
    public void removeItem(Item item)
    {
        inventoryList.Remove(item);
    }
    public Item GetItemFromInventory(int index)
    {
        if (index < 0 || index >= inventoryList.Count) return null;
        return inventoryList[index];
    }

}
