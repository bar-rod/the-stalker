using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PrototypeMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed;
    [SerializeField] private InputActionAsset inputActions;
    private InputActionMap actionMap;
    private InputAction moveAction;
    private InputAction interactAction;
    private Vector2 movementInput;
    private bool _playerTouchingInteractable = false;
    private Iinteractable interactableObject;
    private bool _interactableOpened = false;
    private Rigidbody2D _rb;
    private Collider2D _touchedObject;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        actionMap = inputActions.FindActionMap("Player");
        moveAction = actionMap.FindAction("Move");
        interactAction = actionMap.FindAction("Interact");
    }

    private void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        interactAction.started += OnInteract;

        moveAction.Enable();
        interactAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        interactAction.started -= OnInteract;

        moveAction.Disable();
        interactAction.Disable();
    }
    private void OnMove(InputAction.CallbackContext ctx)
    {
        Debug.Log("Moving");
        movementInput = ctx.ReadValue<Vector2>();
    }

    private void OnInteract(InputAction.CallbackContext ctx)
    {
        Debug.Log("Interacting");
        if (_playerTouchingInteractable == true && _interactableOpened == false)
        {
            interactableObject.Interact(_touchedObject);
            if (_touchedObject.gameObject.GetComponent<Item>() != null) return;
            _interactableOpened = true;
        }
        else if (_playerTouchingInteractable == true && _interactableOpened == true)
        {
            interactableObject.CloseUI(_touchedObject);
            _interactableOpened = false;
        }
    }

    private void Update()
    {
        _rb.linearVelocity = movementInput * speed;
    }

//
    void OnTriggerEnter2D(Collider2D collision)
    {
        _playerTouchingInteractable = true;
        //Getting the Iinteractable component, because both Item and InteractableUI implements Iinteractable interface
        //and will allow us to use the same method from different scripts depending on what was collided with
        interactableObject = collision.GetComponent<Iinteractable>();
        Debug.Log($"collided with {collision.name}");
        _touchedObject = collision;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        _playerTouchingInteractable = false;
        interactableObject = null;
        _touchedObject = null;
    }
}
