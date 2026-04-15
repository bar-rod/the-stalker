using UnityEngine;

public class KeyToolBox : Item
{
    [SerializeField] private Toolbox_Inventory Vent;

    public AudioSource _itemPickedUp;

    public override bool UseItem()
    {


         if(Vent.in_vent){
            Vent.UseItem(this);
            return true;
        }
        else{
            Debug.Log("This cant be used here");
            return false;
        }
    }

    public void onClick()
    {
        _itemPickedUp.Play();
        Pickup();
    }
}

