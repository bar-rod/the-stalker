using UnityEngine;

public class TESTINTERACTABLE : PuzzleInteractable
{
    public override void UseItem(Item item)
    {
        if (itemIDNeeded == item.id)
        {
            // this is where behavior would go for solving the puzzle
            Debug.Log(item.name + (" is the correct item"));
        }
        else
        {
            // this is where you would have a hint message pop up to guide the player to the correct item
            Debug.Log(item.name + " is the incorrect item");
        }
        CloseUI(null);
    }

    // helper functions are ok, just make them private if possible
}
