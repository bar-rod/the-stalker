using System.Data;
using UnityEngine;

[ExecuteInEditMode]
public abstract class Item : MonoBehaviour
{

    /*
     *  Abstract base class for all items
     *  That is, anything the player can pick up and use later
     */
    [SerializeField] public bool RemoveOnUse = true;
    public string itemName; // the name displayed in the inventory
    public Sprite itemSprite; // the icon displayed
    public Sprite itemSpriteInv; //the icon displayed in the inventory
    public string description; // the description displayed when hovered in the inventory
    public int id; // the ID of the item (needs to match puzzleInteractable where the item can be used. Use -1 if item is NOT used on a puzzleInteractable)
    public bool initiallyActive; // 'true' if the item should be active on scene load. 'false' if it should be hidden.

    private AudioSource _collectSound; // sound for picking up the item 
                                       // we should maybe have a default value here
    
    protected virtual void Start()
    {
        if (initiallyActive) gameObject.SetActive(true);
        //GetComponent<SpriteRenderer>().sprite = itemSprite;

        _collectSound = GetComponent<AudioSource>();
    }

    // Interact just calls the Pickup() function. It should not be overriden in most cases
    public virtual void Interact(Collider2D other)
    {
        Pickup();
    }

    // Sets the item to be active in the scene. Useful if solving something else causes an item to appear
    public virtual void SetVisible()
    {
        gameObject.SetActive(true);
    }

    // Use <itemName>.ToString() in debug lines to see name, id, description, whether it is active or not, and id
    // should not be used for logic
    public override string ToString()
    {
        return itemName + "\nID Number: " + id + "\n" + description + "\n\nInitially Active?: " + initiallyActive + "\nSprite: " + itemSprite;
    }
    
    // Called when the item is interacted with
    // This is NOT virtual, so do not repeat implementation if you override this function
    public void Pickup()
    {
        _collectSound.Play();

        gameObject.SetActive(false);

        GameManager.ItemPickedUp.Invoke(this);
    }

    // runs when the player clicks an item in their inventory
    // this is left ABSTRACT which means there is NO default behavior
    // you NEED to override it in your implementation
    // DO NOT remove the item from the inventory in this function; the inventory manager already handles it.
    public abstract bool UseItem();
}
