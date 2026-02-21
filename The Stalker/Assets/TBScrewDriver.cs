using UnityEngine;

public class TBScrewDriver : Item
{
    public override bool UseItem()
    {
        return RemoveOnUse;
    }
}

