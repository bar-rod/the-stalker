using UnityEngine;

public class Room3Manager : MonoBehaviour
{
    [SerializeField] GameObject openedCabinet;
    [SerializeField] ExitDoor exit;
    [SerializeField] PuzzleInteractable interact;

    void Update()
    {
        if(exit.correct)
        {
            openedCabinet.SetActive(false);
            //interact.Interact();
        }
    }
}
