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
    
    private void Awake()
    {
        _ClueBoardCanvas.SetActive(false);
        actionMap = playerControls.FindActionMap("Player");
        playerInteract = actionMap.FindAction("Interact");
        _playerTouchingClue = false;
        ClueBoardOpen = false;

    }
    private void OnEnable()
    {

        //playerInteract = inputActions.Player.Interact;
        
        playerInteract.started += Interact;
        playerInteract.Enable();
    }

    private void OnDisable()
    {
        playerInteract.Disable();
    }

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

    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        _playerTouchingClue = true;

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
       // _ClueBoardCanvas.SetActive(false);
        _playerTouchingClue = false;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (playerInteract.triggered)
        {
            Debug.Log("hi");
        }
        */
    }
}
