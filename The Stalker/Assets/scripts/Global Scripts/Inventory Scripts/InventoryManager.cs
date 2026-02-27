using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private bool inventoryOpen;
    [SerializeField] public List<Item> inventoryList = new List<Item>();
    [SerializeField] private Canvas inventoryUI;
    public static InventoryManager Instance;

    [SerializeField] private List<Item> inventoryCopy = new List<Item>();

    public Animator animator;

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
        
        inventoryUI=GameObject.Find("InventoryCanvas").GetComponent<Canvas>();
        
    }
    void Start()
    {
        inventoryUI.gameObject.SetActive(false);
        inventoryOpen = false;
    }

    private void OnEnable()
    {
        GameManager.ItemPickedUp += AddItem;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        GameManager.ItemPickedUp += AddItem;
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void ToggleInventory()
    {
        if (inventoryOpen)
        {
            animator.SetBool("IsOpen", false);
            inventoryOpen = false;
        }
        else
        {
            inventoryUI.gameObject.SetActive(false);
            inventoryUI.gameObject.SetActive(true);
            animator.SetBool("IsOpen", true);
            inventoryOpen = true;
        }
    }

    public void AddItem(Item item)
    {
        inventoryList.Add(item);

        // ===========================================
        // im really not a fan of this :/
        // at some point, refactor this code into the PocketWatch item script
        if (item.name == "PocketWatch")
        {
            LocatorDialogue.Instance.DialogueScript.SawClueBoard = true;
            LocatorDialogue.Instance.DialogueScript.ShowElisaText("Would this increase my time?", 6);
        }
        // ===========================================

        if (!GetInventoryOpen()) ToggleInventory();
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
        if (PuzzleInteractable.ActivePuzzle != null)
        {
            PuzzleInteractable.ActivePuzzle.UseItem(item);
            return;
        }

        bool useditem = item.UseItem();
        if (useditem)
        {
            RemoveItem(item);
        }
    }
    public bool GetInventoryOpen(){
     return inventoryOpen;   
    }
    public List<Item> GetInventory()
    {
        return inventoryList;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);
        saveInventory();
    }

    public static void saveInventory()
    {
        Debug.Log("Inventory state saved");
        Instance.inventoryCopy = Instance.inventoryList.ConvertAll(item => item.Clone());
    }

    public static void loadInventory()
    {
        Debug.Log("Inventory state loaded");
        Instance.inventoryList = Instance.inventoryCopy.ConvertAll(item => item.Clone());
    }

}
