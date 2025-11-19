using UnityEngine;

public class Screwdriver : Item
{
    [SerializeField] private Vent_Inventory Vent;
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
}

