using UnityEngine;

public class Room3Manager : MonoBehaviour
{
    [SerializeField] GameObject openedCabinet;
    [SerializeField] ExitDoor exit;
    [SerializeField] PuzzleInteractable interact;
    [SerializeField] GameObject bg;
    [SerializeField] GameObject openDoor;
    [SerializeField] TrapDoor door;

    void Update()
    {
        if(exit.correct)
        {
            openedCabinet.SetActive(false);
            //interact.Interact();
            openDoor.SetActive(true);
            door.SetMovingTrue();
        }


    }
}
