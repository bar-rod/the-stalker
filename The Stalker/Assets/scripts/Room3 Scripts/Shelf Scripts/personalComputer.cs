// 1. On click opens inventory
// 2. Clicking on the appropriate item in the inventory will solve the puzzle and open the pc
// 3. PC sprite change to open pc sprite

// So basically I had to copy from puzzleinteractable and vent inv for this because puzzleinteractable wasn't designed for clicks
// OR because I'm just not skilled enough to make it work with clicks
// Later we should split this into a interactable abstract base class but I'm on a deadline here sooooo

using UnityEngine;


public class personalComputer : MonoBehaviour
{
    protected bool isSolved = false;
    protected InventoryManager inventory;
    [SerializeField] Player player;
    [SerializeField] int itemIDRequired;
    [SerializeField] Sprite newSprite;

    void Start()
    {
        inventory = FindFirstObjectByType<InventoryManager>();
    }

    // this replaces the interact method of puzzleInteractable
    // you make a button component then connect this method to it
    public void onClick()
    {
        if (isSolved)
            return;

        else
        {
            inventory.ToggleInventory();
        }
    }

    // TODO: Make this get called when player clicks on items in open inv but how??
    public void useItem(Item item)
    {
        if (item == null)
            return;

        if(item.id == itemIDRequired)
        {
            isSolved = true;
            solve();
        }
    }

    // If we split this into an abstract class, put this as an overridden function.
    public void solve()
    {
        // change the sprite for this game object
        SpriteRenderer s = gameObject.GetComponent<SpriteRenderer>();
        if (s != null)
        {
            s.sprite = newSprite;
        }
    }
}
