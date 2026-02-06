using UnityEngine;

public class Tire : Item
{
    public override bool UseItem()
    {
        return RemoveOnUse;
    }

    public void CollectTire()
    {
        InventoryManager.Instance.AddItem(this);
        gameObject.SetActive(false);
    }
}
