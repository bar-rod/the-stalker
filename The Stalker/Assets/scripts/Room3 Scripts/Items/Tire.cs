using UnityEngine;

public class Tire : Item
{
    public override bool UseItem()
    {
        return RemoveOnUse;
    }
}
