using UnityEngine;
using UnityEngine.UI;
public class CarTire : PuzzleInteractable
{
    [Header("UI")]
    [SerializeField] private Canvas puzzleCanvas;
    [SerializeField] private Image tireImage;
    [SerializeField] private Button[] boltButtons;

    [Header("Item IDs")]
    [SerializeField] private int TIRE_ID;
    [SerializeField] private int BOLTS_ID;
    [SerializeField] private int WRENCH_ID;

    private TireState currentState = TireState.Idle;
    private Item activeItem;

    private int boltsPlaced = 0;
    private int[] boltTightenCount;
    protected override void Start()
    {
        base.Start();

        puzzleCanvas.gameObject.SetActive(false);
        tireImage.enabled = false;

        boltTightenCount = new int[boltButtons.Length];
    }
    public override bool Interact()
    {
        if (isSolved) return false;

        puzzleCanvas.gameObject.SetActive(true);
        player.SetUIOpenTrue();
        inventory.ToggleInventory();

        currentState = TireState.PlacingTire;
        return true; 
    }

    private void ClosePuzzle()
    {
        puzzleCanvas.gameObject.SetActive(false);
        player.SetUiOpenFalse();
    }

    public override void UseItem(Item item)
    {
        activeItem = item;

        switch (currentState)
        {
            case TireState.PlacingTire:
                if (item.id == TIRE_ID)
                    Debug.Log("Tire selected");
                break;

            case TireState.PlacingBolts:
                if (item.id == BOLTS_ID)
                    Debug.Log("Bolts selected");
                break;

            case TireState.TighteningBolts:
                if (item.id == WRENCH_ID)
                    Debug.Log("Wrench selected");
                break;
        }
    }

    public void OnTireClicked()
    {
        Debug.Log(currentState);
        if (currentState != TireState.PlacingTire) return;
        if (activeItem == null || activeItem.id != TIRE_ID) return;

        tireImage.enabled = true;
        inventory.RemoveItem(activeItem);
        activeItem = null;

        currentState = TireState.PlacingBolts;
        inventory.ToggleInventory();
    }

    public void OnBoltPlaced(Button bolt)
    {
        if (currentState != TireState.PlacingBolts) return;
        if (activeItem == null || activeItem.id != BOLTS_ID) return;

        bolt.interactable = false;
        boltsPlaced++;

        if (boltsPlaced >= boltButtons.Length)
        {
            inventory.RemoveItem(activeItem);
            activeItem = null;
            currentState = TireState.TighteningBolts;
        }
    }

    public void OnBoltTightened(int boltIndex)
    {
        if (currentState != TireState.TighteningBolts) return;
        if (activeItem == null || activeItem.id != WRENCH_ID) return;

        boltTightenCount[boltIndex]++;

        if (boltTightenCount[boltIndex] >= 3)
        {
            boltButtons[boltIndex].interactable = false;
        }

        if (AllBoltsTight())
        {
            inventory.RemoveItem(activeItem);
            CompletePuzzle();
        }
    }

    private bool AllBoltsTight()
    {
        foreach (int count in boltTightenCount)
        {
            if (count < 3) return false;
        }
        return true;
    }

    private void CompletePuzzle()
    {
        isSolved = true;
        currentState = TireState.Solved;

        ClosePuzzle();
        Debug.Log("Tire puzzle solved!");
    }
}