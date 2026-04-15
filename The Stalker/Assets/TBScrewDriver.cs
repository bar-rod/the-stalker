using UnityEngine;

public class TBScrewDriver : Item
{
    [SerializeField] Canvas computerCanvas;
    [SerializeField] personalComputer computer;
    public AudioSource _itemPickedUp;

    public override bool UseItem()
    {
        if (computerCanvas.isActiveAndEnabled)
        {
            _itemPickedUp.Play();
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

