using UnityEditor.Build;
using UnityEngine;

public class Bolts : Item
{
    public override bool UseItem()
    {
        return RemoveOnUse;
    }
}
