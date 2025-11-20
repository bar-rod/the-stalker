using UnityEngine;
using UnityEngine.Rendering;

public abstract class PuzzleInteractable : MonoBehaviour, Iinteractable
{

    /* 
     * Abstract base class for any object that 
     * 1. the player needs to interact with and 
     * 2. needs an item to "solve"
     */


    protected bool isSolved = false;
    protected InventoryManager inventory;
    [SerializeField] protected Player player;
    [SerializeField] protected int itemIDNeeded;

    protected virtual void Start()
    {
        inventory = FindFirstObjectByType<InventoryManager>();
    }

    // runs when the player presses 'e' the first time
    // override this in your implementation
    public virtual void Interact()
    {
        Debug.Log("Interacted with " + this.gameObject);
    }


    // runs when the player presses 'e' again to close the canvas popup
    // shouldn't need to be overriden, but you can if you want
    public virtual void CloseUI()
    {
        player.ToggleInventory();
    }

    // runs when the player clicks an item in their inventory
    // this is left ABSTRACT which means there is NO default behavior
    // you NEED to override it in your implementation

    // in most cases, you will probably call item.UseItem()
    public abstract void UseItem(Item item);
}