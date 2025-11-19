using UnityEngine;

public class Vent_Inventory : PuzzleInteractable
{
     [SerializeField] private GameObject theCanvas;
     [SerializeField] public bool in_vent; 
    public override void UseItem(Item item)
    {
         if (itemIDNeeded == item.id)
            {
                // this is where behavior would go for solving the puzzle
                Debug.Log(item.name + (" is the correct item"));
                player.ToggleInventory();

                theCanvas.SetActive(true);
                player._interactableOpened = true;
                isSolved = true;

            }
            else
            {
                // this is where you would have a hint message pop up to guide the player to the correct item (or a different fail condition)
                Debug.Log(item.name + " is the incorrect item");
            }
        //base.CloseUI(null);
    }
    public override void Interact(Collider2D other)
    {
        Debug.Log("Called Interact() from PuzzleInteractable");
        if (isSolved) {
            theCanvas.SetActive(true);
            player._interactableOpened = true;
        }
        else{
            player.ToggleInventory();
            in_vent=true;
        }
        
       //inventory.OpenForPuzzle(UseItem);
    }

    public override void CloseUI(Collider2D other)
    {
        if(theCanvas.activeSelf == true){
            theCanvas.SetActive(false);
            player._interactableOpened = false;
        }
        else
        {
             player.ToggleInventory();
             in_vent=false;
        }

    }
    // helper functions are ok, just make them private if possible
}

