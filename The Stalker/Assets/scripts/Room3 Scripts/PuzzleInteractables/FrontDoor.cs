using UnityEngine;

public class FrontDoor : PuzzleInteractable
{
    [Header("UI")]
    [SerializeField] private Canvas puzzleCanvas;
    public AudioSource _doorOpenedSound;

    private bool isOpen = false;

    protected override void Start()
    {
        base.Start();
        puzzleCanvas.gameObject.SetActive(false);
    }

    public override bool Interact()
    {
        if (isSolved) return false;

        // If canvas closed → open it
        if (!isOpen)
        {
            puzzleCanvas.gameObject.SetActive(true);
            isOpen = true;
            return true;
        }
        // If canvas open → close it
        else
        {
            _doorOpenedSound.Play();
            puzzleCanvas.gameObject.SetActive(false);
            isOpen = false;
            CloseUI();
            return false;
        }
    }

    public override void UseItem(Item item)
    {
        // We don't need this if items aren't "used"
    }
}