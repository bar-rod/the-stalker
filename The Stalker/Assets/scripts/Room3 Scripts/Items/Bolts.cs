using UnityEditor.Build;
using UnityEngine;

public class Bolts : Item
{
    public override bool UseItem()
    {
        return RemoveOnUse;
    }

    public void CollectBolts()
    {
        InventoryManager.Instance.AddItem(this);
        InventoryManager.Instance.ToggleInventory();
        gameObject.SetActive(false);
    }
}
