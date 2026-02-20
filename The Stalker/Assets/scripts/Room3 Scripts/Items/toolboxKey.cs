using UnityEngine;

public class ToolBoxKey : Item
{
    public override bool UseItem()
    {
        return RemoveOnUse;
    }
}
