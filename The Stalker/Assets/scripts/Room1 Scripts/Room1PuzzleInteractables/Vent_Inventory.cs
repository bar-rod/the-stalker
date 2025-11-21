using UnityEngine;

public class Vent_Inventory : PuzzleInteractable
{
     [SerializeField] private GameObject theCanvas;
     [SerializeField] public bool in_vent; 
     private bool bCanvasActive = false;
    public override void UseItem(Item item)
    {
         if (itemIDNeeded == item.id)
            {
                // this is where behavior would go for solving the puzzle
                Debug.Log(item.name + (" is the correct item"));
                //inventory.ToggleInventory();

                theCanvas.SetActive(true);
                isSolved = true;

            }
            else
            {
                // this is where you would have a hint message pop up to guide the player to the correct item (or a different fail condition)
                Debug.Log(item.name + " is the incorrect item");
            }
        //base.CloseUI(null);
    }
    public override void Interact()
    {
        Debug.Log("Called Interact() from PuzzleInteractable");
        if (isSolved&&bCanvasActive==false) {
            theCanvas.SetActive(true);
            bCanvasActive=true;
        }
        else if(in_vent==false&&bCanvasActive==false){
            inventory.ToggleInventory();
            in_vent=true;
            bCanvasActive=true;
        }
        else if(bCanvasActive==true){
            CloseUI();
            bCanvasActive=false;
        }
       //inventory.OpenForPuzzle(UseItem);
    }

    public override void CloseUI()
    {
        if(theCanvas.activeSelf == true){
            theCanvas.SetActive(false);

        }
        else
        {
             player.ToggleInventory();
             in_vent=false;
        }

    }
    // helper functions are ok, just make them private if possible
}

