using UnityEngine;

public class TESTINTERACTABLE : PuzzleInteractable
{
    // extra variables are fine, just make them private if possible/needed

    // this is purely an example class, so you can see how to add your own logic
    public override void UseItem(Item item)
    {
        // make sure you update the itemIDNeeded variable in the inspector to the same ID as the item needed to solve the puzzle
        if (itemIDNeeded == item.id)
        {
            // this is where behavior would go for solving the puzzle
            Debug.Log(item.name + (" is the correct item"));
        }
        else
        {
            // this is where you would have a hint message pop up to guide the player to the correct item (or a different fail condition)
            Debug.Log(item.name + " is the incorrect item");
        }
        // CloseUI can go here, at the end, to force the player out of the interactable
        // alternatively, you can place it at the bottom of the if statement (last line before the else)
        // to only close the UI if the correct item is used
        CloseUI();
    }

    // helper functions are ok, just make them private if possible/needed
}
