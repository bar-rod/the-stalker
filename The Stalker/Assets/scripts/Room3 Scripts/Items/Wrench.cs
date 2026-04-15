using UnityEngine;

public class Wrench : Item
{
public AudioSource _itemPickedUp;
 
    public override bool UseItem()
    {
        _itemPickedUp.Play();
        return RemoveOnUse;
    }
}
