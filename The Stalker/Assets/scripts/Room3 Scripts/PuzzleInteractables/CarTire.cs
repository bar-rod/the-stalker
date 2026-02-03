using UnityEngine;

public class CarTire : PuzzleInteractable
{
    [SerializeField] private GameObject _tireCanvas;
    [SerializeField] private GameObject _trunkCanvas;

    private int _tireState = 0;
    /*
     *  0 -> tire not yet placed
     *  1 -> tire placed, no bolts placed
     *  2 -> bolts placed, but not screwed
     *  3 -> bolts screwed (done)
     */

    // item id needed on parent script is the same as the tire id    
    

    
    public override bool Interact()
    {
        if (_tireState == 0)
        {
            Debug.Log("Tire is missing");
            player.ToggleInventory();
        }
        else if (_tireState >= 1) 
        {
            OpenTireCanvas();
        }
        return true;
    }

    public override void UseItem(Item item)
    {
        if (_tireState == 0) TryPlaceTire(item);
        else if (_tireState == 1) Debug.Log("I need something to attach the tire");
        else if (_tireState == 2) Debug.Log("I need something to tighten these");
        CloseUI();
    }

    private void TryPlaceTire(Item item)
    {
        if (item.id != itemIDNeeded)
        {
            Debug.Log("wrong item");
            return;
        }

        Debug.Log("tire placed");
        _tireState = 1;

        OpenTireCanvas();
    }

    private void OpenTireCanvas()
    {
        _tireCanvas.SetActive(true);

        // update the tire canvas
    }

    public void AllBoltsPlaced()
    {
        _tireState = 2;
    }

    public void AllBoltsTightened()
    {
        _tireState = 3;
        isSolved = true;

        _tireCanvas.SetActive(false);
        _trunkCanvas.SetActive(true);
    }
}
