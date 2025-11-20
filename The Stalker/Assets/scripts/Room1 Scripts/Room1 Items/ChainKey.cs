using UnityEngine;

public class ChainKey : Item
{

    public ChainConstraint chainConstraint;
    public TargetJoint2D chainConnector;
    public override bool UseItem() 
    {
        Debug.Log("using chain key");

        chainConstraint.BreakChain();
        chainConnector.enabled = false;

        return true; // item is consumed on use
    }
}
