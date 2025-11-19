using UnityEngine;

public class TESTITEM : Item
{
    public override bool UseItem()
    {
        Debug.Log(name + " was used!");
        return true;
    }
}
