using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] float charSpeed;
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] private AudioSource _walkingSound;

    [SerializeField] GameObject _bedCollider;
    [SerializeField] CapsuleCollider2D _collider;
    //[SerializeField] private Collider2D _collider4;
    
    Vector2 currentY;
    private bool waitingToChange;
    private float exitTimer = 0f;
    
    private Rigidbody2D rb;
    private Vector2 currentMoveInput;
    private Vector2 filteredInput;
    private Collider2D _touchedObject;
    public bool _interactableOpened;
    private Iinteractable interactableObject;
    private ObjectOutline _outline;

    private InputActionMap actionMap;
    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction inventoryAction;
    private float walkSpeed;
    


    private ChainConstraint chain;
    private List<Iinteractable> _interactables = new  List<Iinteractable>();
    private Iinteractable currentInteractable;
    private bool _bUIOpened = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        chain = GetComponent<ChainConstraint>();

        actionMap = inputActions.FindActionMap("Player");
        moveAction = actionMap.FindAction("Move");
        interactAction = actionMap.FindAction("Interact");
        inventoryAction = actionMap.FindAction("Inventory");
        walkSpeed=charSpeed;
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
        inventoryAction.Disable();
    }

    void FixedUpdate()
    {
        
        Vector2 proposedVelocity = new Vector2(currentMoveInput.x * charSpeed, currentMoveInput.y * charSpeed);
        rb.linearVelocity = chain.FilterMovement(proposedVelocity) * charSpeed; // when chain is not enabled, FIlterMovement returns proposedVelocity with no modifications
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        currentMoveInput = ctx.ReadValue<Vector2>().normalized;

        //animation!! 
        if (currentMoveInput != new Vector2(0,0) && !_interactableOpened)
        {
            _animator.SetBool("isWalking", true);
            _sprite.flipX = currentMoveInput[0] > 0f;
            _walkingSound.Play();
        } 
        else
        {
            _animator.SetBool("isWalking", false);
            _walkingSound.Stop();
        }
    }

    //triggers when e is pressed and is currently within the range of an interactable object's colliders
    private void OnInteract(InputAction.CallbackContext ctx)
    {

        if (_interactables.Count == 0) return;
        
        _bUIOpened = _interactables[0].Interact();
    }
    private void OnInventory(InputAction.CallbackContext context)
    {
        ToggleInventory();
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
    
    public void ToggleInventory()
    {
        inventoryManager.ToggleInventory();
    }

    void Update()
    {
        if (_bUIOpened)
        {
            charSpeed = 0;
        }
        else
        {
            charSpeed = walkSpeed;
        }

        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "FINAL room 1")
        {
            if (this.transform.position.y > _bedCollider.transform.position.y)
            {
                _sprite.sortingOrder = 4;
            }
            else
            {
                _sprite.sortingOrder = 7;
            }
        }

    }
}
