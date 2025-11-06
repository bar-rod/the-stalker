using UnityEngine;

public abstract class PuzzleInteractable : MonoBehaviour, Iinteractable
{

    /*
     *  This script might be super unhelpful tbh. I think we would need to create a subclass for each item, 
     *  which seems like a lot of work. I just don't know the best way to create a function that can have
     *  a bunch of different results without overriding a bunch of functions. Lmk if you can think of a way
     *  and I'll implement it, but for now, this works, it just seems inefficient.
     *  
     *  ^^ SCRATCH THAT WE'RE USING INHERITANCE BABY YAHOO
     *  
     *  NOTE: THIS CLASS IS ABSTRACT, SO IT NEEDS TO BE SUBCLASSED TO WORK PROPERLY
     *        LET ME (JACKSON) KNOW IF YOU NEED TO KNOW HOW TO OVERRIDE THE UseItem() FUNCTION
     *        I ALSO MADE A TESTINTERACTABLE.cs THAT WORKS AS A TEMPLATE TO FOLLOW
     */


    protected bool isSolved = false;
    protected Inventory inventory;
    [SerializeField] protected Player player;
    [SerializeField] protected int itemIDNeeded;

    protected virtual void Start()
    {
        inventory = FindFirstObjectByType<Inventory>();
    }

    public virtual void Interact(Collider2D other)
    {
        if (isSolved) return;

        player.puzzleMode = true;
        inventory.OpenForPuzzle(UseItem);
    }

    public virtual void CloseUI(Collider2D other)
    {
        //inventory.ItemUsedOnPuzzle = null; // IF SOMETHING LOOKS BROKEN ITS PROBABLY THIS
        Debug.Log("ItemUsedOnPuzzle is null");
        player.ToggleInventory();
    }
    public abstract void UseItem(Item item); // this gets overriden
}