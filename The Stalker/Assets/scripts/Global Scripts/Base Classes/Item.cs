using System.Data;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Item : MonoBehaviour, Iinteractable
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
    private bool _isActive = true; // whether the item is active in the scene or not. This is used to determine whether the item can be interacted with or not. It is set to 'initiallyActive' on scene load, but can be changed by other scripts (e.g. if solving a puzzle causes an item to appear)
    private AudioSource[] _collectSound; // sound for picking up the item 
                                      // we should maybe have a default value here
    
    protected virtual void Start()
    {
        if (initiallyActive) gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = itemSprite;

        _collectSound = GetComponents<AudioSource>();
    }

    protected virtual void FixedUpdate()
    {
        // Once the sound finishes playing, we can disable the game object.

        bool soundComplete = true;

        for(int i = 0; i < _collectSound.Length; i++)
            if(_collectSound[i].isPlaying)
                soundComplete = false;

        if (soundComplete && !gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            gameObject.SetActive(false);
        }
    }

    // Interact just calls the Pickup() function. It should not be overriden in most cases
    public virtual bool Interact()
    {
        for(int i = 0; i < _collectSound.Length; i++)
        {
            _collectSound[i].Play();
        }

        if (_isActive)
            Pickup();

        return false;
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
        Debug.Log("Picked up " + itemName + ", sound is not null: " + (_collectSound != null) + " and it is " + (_collectSound.ToString()));
        if(gameObject.GetComponent<SpriteRenderer>() != null)
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        if(gameObject.GetComponent<Image>() != null)
            gameObject.GetComponent<Image>().enabled = false; 
        GameManager.ItemPickedUp.Invoke(this);
        _isActive = false;
    }

    // runs when the player clicks an item in their inventory
    // this is left ABSTRACT which means there is NO default behavior
    // you NEED to override it in your implementation
    // DO NOT remove the item from the inventory in this function; the inventory manager already handles it.

    // return true to remove the item from the inventory after use
    // return false if it should stay in the inventory
    public virtual bool UseItem()
    {
        //TEMPORARY CODE
        Debug.Log("Use Item");
        return true;
    }
    public Item Clone()
    {
        Item newItem = new Item();
        newItem.itemName = this.itemName;
        newItem.itemSprite = this.itemSprite;
        newItem.itemSpriteInv = this.itemSpriteInv;
        newItem.description = this.description;
        newItem.id = this.id;
        newItem.initiallyActive = this.initiallyActive;
        newItem._collectSound = this._collectSound;
        return newItem;
    }
}