using UnityEngine;

public class Tire : Item
{
    public AudioSource _itemPickedUp;
    public override bool UseItem()
    {
        //_itemPickedUp.Play();
        return RemoveOnUse;
    }

    public void CollectTire()
    {
        InventoryManager.Instance.AddItem(this);
        gameObject.SetActive(false);
    }
}
