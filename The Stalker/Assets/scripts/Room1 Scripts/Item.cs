using System.Data;
using UnityEngine;

[ExecuteInEditMode]
public class Item : MonoBehaviour, Iinteractable
{
    public string itemName;
    public Sprite itemSprite;
    public string description;
    public int id;
    public bool initiallyActive;
   
    void Start()
    {
        if (initiallyActive) gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }

    //equivalence of pick up basically
    public void Interact(Collider2D other)
    {
        Debug.Log("Called Interact() from Item");
        gameObject.SetActive(false);
        Inventory inventory = FindFirstObjectByType<Inventory>();
        if (inventory != null)
        {
            inventory.inventoryList.Add(this);

            //display UI that shows the item that was just collected



            // check if item was chain key
            // if it was, force the player through an inventory tutorial
            if (id == 0) 
            {
                Player player = GetComponent<Player>();
                player.ToggleInventory();

                //tutorial content

            }
        }
        else // this is just to catch errors
        {
            Debug.LogWarning("No Inventory found on " + other.name);
        }
        CloseUI(other);
    }

    public void CloseUI(Collider2D other)
    {
        // theres no UI for item, but we need to call it anyways
        // this function just resert
    }

    public void ShowItem()
    {
        gameObject.SetActive(true);
    }
    
    public override string ToString()
    {
        return itemName + "\nID Number: " + id + "\n" + description + "\n\nInitially Active?: " + initiallyActive + "\nSprite: " + itemSprite;
    }
}
