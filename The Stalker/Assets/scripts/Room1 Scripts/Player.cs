using System;
using System.Security.Claims;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] float charSpeed;
    [SerializeField] GameObject inventory;
    private Rigidbody2D rb;
    private Vector2 currentMoveInput;
    private Vector2 filteredInput;
    private bool _playerTouchingInteractable;
    private Collider2D _touchedObject;
    private bool _interactableOpened;
    private Iinteractable interactableObject;

    private InputActionMap actionMap;
    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction inventoryAction;


    private ChainConstraint chain;

    private bool inventoryIsOpen = false;
    public bool puzzleMode = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        chain = GetComponent<ChainConstraint>();

        actionMap = inputActions.FindActionMap("Player");
        moveAction = actionMap.FindAction("Move");
        interactAction = actionMap.FindAction("Interact");
        inventoryAction = actionMap.FindAction("Inventory");
    }

    private void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        interactAction.started += OnInteract;
        inventoryAction.started += OnInventory;

        moveAction.Enable();
        interactAction.Enable();
        inventoryAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        interactAction.started -= OnInteract;
        inventoryAction.started -= OnInventory;

        moveAction.Disable();
        interactAction.Disable();
    }

    void FixedUpdate()
    {
        Vector2 proposedVelocity = new Vector2(currentMoveInput.x * charSpeed, currentMoveInput.y * charSpeed);
        rb.linearVelocity = chain.FilterMovement(proposedVelocity) * charSpeed; // when chain is not enabled, FIlterMovement returns proposedVelocity with no modifications
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        currentMoveInput = ctx.ReadValue<Vector2>().normalized;
    }

    //triggers when e is pressed and is currently within the range of an interactable object's colliders
    private void OnInteract(InputAction.CallbackContext ctx)
    {
        if (_playerTouchingInteractable == true && _interactableOpened == false)
        {
            interactableObject.Interact(_touchedObject);
            _interactableOpened = true;
        }
        else if (_playerTouchingInteractable == true && _interactableOpened == true)
        {
            interactableObject.CloseUI(_touchedObject);
            _interactableOpened = false;
        }
    }
    private void OnInventory(InputAction.CallbackContext context)
    {
        ToggleInventory();
    }
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
    public void ToggleInventory(bool fromPuzzle = false)
    {
        if (inventoryIsOpen)
        {
            inventory.SetActive(false);
            inventoryIsOpen = false;
        }
        else
        {
            inventory.SetActive(true);
            inventoryIsOpen = true;
        }
        if (!fromPuzzle) puzzleMode = false;
    }
}
