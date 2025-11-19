using UnityEngine;

public class TESTITEM : Item
{
    public override void UseItem()
    {
        Debug.Log(name + " was used!");
    }
}
