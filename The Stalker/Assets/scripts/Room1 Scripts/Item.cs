using UnityEngine;
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
        if (other.tag == "ChainKey")
        {
            //since first key opens the inventory
        }
        else
        {
            //logic for every other item: pop up UI that shows what was collected
        }
        //display UI that shows the item that was just collected
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
