using UnityEngine;

public class Room3Manager : MonoBehaviour
{
    [SerializeField] GameObject openedCabinet;
    [SerializeField] ExitDoor exit;
    [SerializeField] PuzzleInteractable interact;
    [SerializeField] GameObject bg;
    [SerializeField] Sprite newBg;
    [SerializeField] TrapDoor door;

    void Update()
    {
        if(exit.correct)
        {
            openedCabinet.SetActive(false);
            //interact.Interact();
            bg.GetComponent<SpriteRenderer>().sprite = newBg;
            door.SetMovingTrue();
        }


    }
}
