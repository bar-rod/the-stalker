using UnityEngine;

public class Bolts : Item
{
    public AudioSource _itemPickedUp;
    public override bool UseItem()
    {
        _itemPickedUp.Play();
        return RemoveOnUse;
    }

    public void CollectBolts()
    {
        InventoryManager.Instance.AddItem(this);
        InventoryManager.Instance.ToggleInventory();
        gameObject.SetActive(false);
    }
}
