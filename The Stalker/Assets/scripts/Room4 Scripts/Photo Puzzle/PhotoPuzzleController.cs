using UnityEngine;

public class PhotoPuzzleController : MonoBehaviour
{
    public ClueSlot[] slots;
    public int[] solution; // the correct clue order, 0 indexed
    public bool solved = false; // Use this to read puzzle state

    [Header("Debug")]
    public int[] currentOrder = new int[8];
    public bool debug = false;

    public void Check()
    {
        if(solved) return;

        bool isCorrect = true;

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].clue == null || slots[i].clue.clueID != solution[i])
            {
                isCorrect = false;
                break;
            }
        }

        if (isCorrect)
        {
            solved = true;
            // Add a func call here if you want to...say...disable the puzzle from interaction.
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!debug) return;

        for(int i = 0; i < slots.Length; i++)
        {
            if (slots[i].clue != null)
            {
                currentOrder[i] = slots[i].clue.clueID;
            }
            else
            {
                currentOrder[i] = -1; // -1 indicates
            }
        }
    }
}
