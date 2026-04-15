using UnityEngine;
using UnityEngine.UI;

// Issue: pressing e on toolbox disables movement.
// Issue2: sometimes the scredriver is not interactable.
// Issue3: the sprite resets to its old one

public class Toolbox_Inventory : PuzzleInteractable
{
    [SerializeField] private GameObject screwDriver;
    [SerializeField] private GameObject theCanvas;
    [SerializeField] public bool in_vent; 
    [SerializeField] private KeyToolBox key;
    [SerializeField] private ObjectOutline outline;
    
    //related to Elisa's dialogue
    public bool hint = false;
    public bool hintWKey = false;
    public bool toolBoxOpen = false;

    public AudioSource _tbOpenedSound;


    // new sprite
    [SerializeField] public Sprite newSprite;

    private bool bCanvasActive = false;

    void Update()
    {
        if(toolBoxOpen)
        {
            outline.enabled = false;
        }
    }
    public override void UseItem(Item item)
    {
        if (itemIDNeeded == item.id)
            {
                // this is where behavior would go for solving the puzzle
                Debug.Log(item.name + (" is the correct item"));
                //inventory.ToggleInventory(); why is this here?
                _tbOpenedSound.Play();
                theCanvas.SetActive(false);
                screwDriver.SetActive(true);
                isSolved = true;
                this.GetComponent<BoxCollider2D>().enabled = false; // disable collider so it can't be interacted with again
                // get the script
            
            // update sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (newSprite != null && spriteRenderer != null)
            {
                spriteRenderer.sprite = newSprite;
                toolBoxOpen = true;
            }

            else
                Debug.LogWarning("New sprite or SpriteRenderer is missing for " + gameObject.name);

        }
        else
        {
            // this is where you would have a hint message pop up to guide the player to the correct item (or a different fail condition)
            Debug.Log(item.name + " is the incorrect item");
            hint = true;
        }
        //base.CloseUI(null);
    }
    public override bool Interact()
    {
        //plays hint for the player
        if(inventory.inventoryList.Count==0)   
        {
            hint = true;
        }

        if(inventory.inventoryList.Contains(key))
        {
            hintWKey = true;
        }

        Debug.Log("Called Interact() from PuzzleInteractable");
        
        if (isSolved&&bCanvasActive==false) 
        {
            theCanvas.SetActive(false);
            bCanvasActive=false;
            return false;
        }
        else if(in_vent==false&&bCanvasActive==false){

            /* We have to add the relevant dialogue here
            if (!LocatorDialogue2.Instance.Dialogue2Script.ElisaAudioPlaying)
            {
                LocatorDialogue2.Instance.Dialogue2Script.ShowElisaText("What can I use to open the vent?", 2);
            }
            */

            if(inventory.GetInventoryOpen()==false){
            inventory.ToggleInventory();
            }
            in_vent=true;
            bCanvasActive=false;
            return false;
        }
        else if(bCanvasActive==true){
            CloseUI();
            bCanvasActive=false;
            return false;
        }

        return false;
        //inventory.OpenForPuzzle(UseItem);
    }

    public override void CloseUI()
    {
        if(theCanvas.activeSelf == true){
            theCanvas.SetActive(false);
            in_vent=false;
        }
        else
        {
             inventory.ToggleInventory();
             in_vent=false;
        }

    }
    // helper functions are ok, just make them private if possible

    private void OnTriggerExit2D(Collider2D collision)
    {
        CloseUI();
    }
}

