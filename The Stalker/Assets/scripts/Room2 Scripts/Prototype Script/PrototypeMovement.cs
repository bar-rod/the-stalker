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
    }

    private void Update()
    {
        _rb.linearVelocity = movementInput * speed;
    }
    
}
