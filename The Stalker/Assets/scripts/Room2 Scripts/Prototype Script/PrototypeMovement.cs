using System.Collections.Generic;
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
    private List<Iinteractable> _interactables = new  List<Iinteractable>();

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

        if (_interactables.Count == 0) return;
        
        _interactables[0].Interact();
    }

    private void Update()
    {
        _rb.linearVelocity = movementInput * speed;
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        //Getting the Iinteractable component, because both Item and InteractableUI implements Iinteractable interface
        //and will allow us to use the same method from different scripts depending on what was collided with
        interactableObject = collision.GetComponent<Iinteractable>();
        if (interactableObject == null) return;
        if (!_interactables.Contains(interactableObject))
        {
            _interactables.Add(interactableObject);
            Debug.Log($"Interactable: {collision.name} added to list");
        }

        //Debug.Log($"collided with {collision.name}");
        //_touchedObject = collision;
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        interactableObject = collision.GetComponent<Iinteractable>();
        if(interactableObject == null) return;

        Debug.Log($"Interactable: {collision.name} removed from list");
        _interactables.Remove(interactableObject);
        
        //interactableObject = null;
        // _touchedObject = null;
        
    }
    
}
