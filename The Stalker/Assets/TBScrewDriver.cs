using UnityEngine;

public class TBScrewDriver : Item
{
    [SerializeField] Canvas computerCanvas;
    [SerializeField] personalComputer computer;

    public override bool UseItem()
    {
        if (computerCanvas.isActiveAndEnabled)
        {
            computer.useItem(this);
            return true;
        }

        else
        {
            Debug.Log("This cannot be used here.");
            return false;
        }

    }
}

