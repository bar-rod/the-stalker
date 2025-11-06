using System;
using System.Collections.Generic;
using UnityEngine;
public class Inventory : MonoBehaviour
{
    public Canvas inventoryUI;
    public List<Item> inventoryList = new List<Item>();
    public delegate void ItemSelected(Item item);
    public Action<Item> ItemUsedOnPuzzle;

    void Start()
    {
        inventoryUI.gameObject.SetActive(false);
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

    public void SelectItem(Item item)
    {
        if (item != null && ItemUsedOnPuzzle != null)
        {
            Debug.Log("Item: " + item.name + " " + item.id);
            ItemUsedOnPuzzle(item);
        }
        else
        {
            Debug.Log("hey vro. u arent in puzzle mode :wilted_rose: (look in Inventory.cs)");
        }

    }

    public void OpenForPuzzle(Action<Item> callback)
    {
        ItemUsedOnPuzzle = callback; // assign delegate
        inventoryUI.gameObject.SetActive(true);
    }
}
