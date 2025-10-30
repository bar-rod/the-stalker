using UnityEngine;
using UnityEngine.InputSystem;

public class OpenClue : MonoBehaviour
{

    //an array of all the canvases/popup menues of the clues
    [SerializeField] private GameObject[] _ClueCanvases;
    [SerializeField] InputActionAsset playerControls;

    private InputActionMap actionMap;
    private InputAction playerInteract;
    private bool _playerTouchingClue;
    private bool _ClueOpen;
    private int _clueCanvasIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        //don't really need this since they will likely be off anyway, but just in a case
        for (int i = 0; i < _ClueCanvases.Length; i++)
        {
            _ClueCanvases[i].SetActive(false);
        }

        actionMap = playerControls.FindActionMap("Player");
        playerInteract = actionMap.FindAction("Interact");

        _playerTouchingClue = false;
        _ClueOpen = false;
    }
    
    private void OnEnable()
    {
        //sets up interaction event
        playerInteract.started += Interact;
        playerInteract.Enable();
    }

    private void OnDisable()
    {
        playerInteract.started -= Interact;
        playerInteract.Disable();
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        /*_ClueCanvases array consists of 
          _ClueCanvases[0] = Clue Board
          _ClueCanvases[1] = Clock
        */

        //if the player is touching a specific clue, it'll designate the index to the clue's canvas
        _playerTouchingClue = true;
        if (collider.CompareTag("ClueBoard"))
        {
            _clueCanvasIndex = 0;
            Debug.Log("Player collided with" + collider.gameObject.name);
        } 
        else if (collider.CompareTag("Clock"))
        {
            _clueCanvasIndex = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        //if they aren't touching a clue, then nothing should happen
        _playerTouchingClue = false;
    }

    private void Interact(InputAction.CallbackContext context)
    {
        //when the player presses E, it should open to the correct canvas
        if (_playerTouchingClue == true && _ClueOpen == false)
        {
            _ClueCanvases[_clueCanvasIndex].SetActive(true);
            _ClueOpen = true;
            //Debug.Log("We interacted with E key!");
        }
        //if one is already open, then pressing E should close it
        else if (_ClueOpen == true)
        {
            _ClueCanvases[_clueCanvasIndex].SetActive(false);
            _ClueOpen = false;
        }

    }
}
