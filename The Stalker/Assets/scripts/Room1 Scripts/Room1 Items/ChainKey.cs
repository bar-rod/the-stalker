using UnityEngine;

public class ChainKey : Item
{

    public ChainConstraint chainConstraint;
    public TargetJoint2D chainConnector;
    [SerializeField] private LightController _light;
    public override bool UseItem() 
    {
        Debug.Log("using chain key");

        chainConstraint.BreakChain();
        LocatorDialogue.Instance.DialogueScript.PlayStalkerEndLines();
        chainConnector.enabled = false;

        _light.turnLightsOff();
        _light.enabled = false;

        return true; // item is consumed on use
    }
}
