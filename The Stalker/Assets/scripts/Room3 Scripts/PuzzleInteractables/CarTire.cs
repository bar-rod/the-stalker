using UnityEngine;
using UnityEngine.UI;
public class CarTire : PuzzleInteractable
{
    const int numOfBolts = 5;
    [SerializeField] private SpriteRenderer carSprite;
    [SerializeField] private Sprite _carSprite;
    [SerializeField] private MonoBehaviour outline;

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
        if (puzzleCanvas.gameObject.activeSelf)
        {
            ClosePuzzle();
            return false;
        }
        if (isSolved) return false;

        puzzleCanvas.gameObject.SetActive(true);
        ActivePuzzle = this;
        player.SetUIOpenTrue();
        player.AllowInventoryWhileUIOpen(true);
        inventory.ToggleInventory();
        if (currentState == TireState.Idle)
        {
            currentState = TireState.PlacingTire;
        }
        return true; 
    }

    private void ClosePuzzle()
    {
        puzzleCanvas.gameObject.SetActive(false);
        player.SetUiOpenFalse();
        player.AllowInventoryWhileUIOpen(false);
        ActivePuzzle = null;
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
        Debug.Log(activeItem.id);
        if (currentState != TireState.PlacingTire) return;
        if (activeItem == null || activeItem.id != TIRE_ID) return;
        Debug.Log(currentState);
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

        if (boltsPlaced >= numOfBolts)
        {
            inventory.RemoveItem(activeItem);
            activeItem = null;
            currentState = TireState.TighteningBolts;
            if (inventory.GetInventoryOpen()) inventory.ToggleInventory();

            for (int i = 0; i < numOfBolts; i++)
            {
                boltButtons[i].interactable = true;
            }
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

        carSprite.sprite = _carSprite;
        outline.enabled = false;

        ClosePuzzle();
        Debug.Log("Tire puzzle solved!");
    }
}