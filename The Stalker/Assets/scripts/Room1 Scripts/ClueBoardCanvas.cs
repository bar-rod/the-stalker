using UnityEngine;
using UnityEngine.InputSystem;

public class ClueBoardCanvas : MonoBehaviour
{
    [SerializeField] private GameObject _ClueBoardCanvas;
    [SerializeField] InputActionAsset playerControls;

    private InputActionMap actionMap;
    private InputAction playerInteract;
    private bool _playerTouchingClue;
    private bool ClueBoardOpen;

    //setting up the Canvas and E key, and some bools
    private void Awake()
    {
        _ClueBoardCanvas.SetActive(false);
        actionMap = playerControls.FindActionMap("Player");
        playerInteract = actionMap.FindAction("Interact");
        _playerTouchingClue = false;
        ClueBoardOpen = false;
        //hi
    }
    
    //enables e as interact key
    private void OnEnable()
    {
        
        playerInteract.started += Interact;
        playerInteract.Enable();
    }

    private void OnDisable()
    {
        playerInteract.started -= Interact;
        playerInteract.Disable();
    }

    // if player is close to clue board or if clueboard is already open
    // clue board will open or close when player presses E
    private void Interact(InputAction.CallbackContext context)
    {
        if (_playerTouchingClue == true && ClueBoardOpen == false)
        {
            _ClueBoardCanvas.SetActive(true);
            ClueBoardOpen = true;
            //Debug.Log("We interacted with E key!");
        }
        else if (ClueBoardOpen == true)
        {
            _ClueBoardCanvas.SetActive(false);
            ClueBoardOpen = false;
        }

    }

    
    //determines whether player is within touching vicinity of clue board to interact with it
    private void OnTriggerEnter2D(Collider2D collider)
    {
        _playerTouchingClue = true;

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
       
        _playerTouchingClue = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
