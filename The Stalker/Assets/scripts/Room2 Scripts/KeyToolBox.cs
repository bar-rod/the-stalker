using UnityEngine;

public class KeyToolBox : Item
{
    [SerializeField] private Toolbox_Inventory Vent;
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

