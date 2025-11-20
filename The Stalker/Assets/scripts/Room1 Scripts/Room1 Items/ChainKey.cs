using UnityEngine;

public class ChainKey : Item
{
    public override bool UseItem() 
    {
        Debug.Log("using chain key");

        // message pop up: "Press 'i' or 'tab' to open your inventory"
        // wait for player to open inventory
        // message pop up: "Click an item to use it"
        // player clicks on chain key
        // disable the chainconstraint script, detach the target joint 2d

        return true; // item is consumed on use
    }
}
