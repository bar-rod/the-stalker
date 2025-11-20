using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private bool inventoryOpen;
    [SerializeField] private List<Item> inventoryList = new List<Item>();
    [SerializeField] private Canvas inventoryUI;
    public static InventoryManager Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        inventoryOpen = false;
        inventoryUI.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.ItemPickedUp += AddItem;
    }
    private void OnDisable()
    {
        GameManager.ItemPickedUp += AddItem;
    }

    public void ToggleInventory()
    {
        if (inventoryOpen)
        {
            inventoryUI.gameObject.SetActive(false);
            inventoryOpen = false;
        }
        else
        {
            inventoryUI.gameObject.SetActive(true);
            inventoryOpen = true;
        }
    }

    public void AddItem(Item item)
    {
        inventoryList.Add(item);
    }
    public void RemoveItem(Item item)
    {
        inventoryList.Remove(item);
    }
    public Item GetItemFromInventory(int index)
    {
        if (index < 0 || index >= inventoryList.Count) return null;
        return inventoryList[index];
    }
    public void UseItem(Item item)
    {
        bool useditem = item.UseItem();
        if (useditem) {
            RemoveItem(item);
        }
        ToggleInventory();
    }
    public List<Item> GetInventory()
    {
        return inventoryList;
    }
}
