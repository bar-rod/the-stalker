using UnityEngine;

public class Wrench : Item
{ 
    public override bool UseItem()
    {
        return RemoveOnUse;
    }
}
