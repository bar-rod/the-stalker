// Slots act as holders and spawn points for clues.
// This is where swapping is implemented

using UnityEngine;
using UnityEngine.EventSystems;

public class ClueSlot : MonoBehaviour, IDropHandler
{
    public photoClue clue;
    private PhotoPuzzleController ppc;

    void Awake()
    {
        if(clue != null)
        {
            clue.currentSlot = this;
        }
    }    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ppc = GameObject.FindAnyObjectByType<PhotoPuzzleController>();

        // shouldnt be necessary but just in case
        if (clue != null)
        {
            updateCluePos();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            photoClue droppedClue = eventData.pointerDrag.GetComponent<photoClue>();
            
            if (droppedClue != null && droppedClue != clue)
            {
                Debug.Log("Swapping " + droppedClue.name + " with " + this.clue.name);

                ClueSlot oldSlot = droppedClue.currentSlot;

                oldSlot.clue = this.clue;
                this.clue.currentSlot = oldSlot;
                oldSlot.updateCluePos();

                this.clue = droppedClue;
                droppedClue.currentSlot = this;
                this.updateCluePos();

                // basically a bootleg message to controller.
                ppc.Check();
            }
        }
    }

    public void updateCluePos()
    {
        // Clue should never be null

        clue.transform.SetParent(this.transform);
        clue.transform.position = this.transform.position;
        clue.currentSlot = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
