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
                inventory.inventoryUI.gameObject.SetActive(true);
                FindFirstObjectByType<OpenInventory>().Disable();

                //tutorial content


                FindFirstObjectByType<OpenInventory>().Disable();
            }
        }
        else // this is just to catch errors
        {
            Debug.LogWarning("No Inventory found on " + other.name);
        }
    }

    public void CloseUI(Collider2D other)
    {
        //set the pop up UI to be Inactive.
    }

    public void ShowItem()
    {
        gameObject.SetActive(true);
    }
    
}
