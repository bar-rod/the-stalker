using System;
using System.Collections;
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
    [SerializeField] Animator _animator;
    [SerializeField] SpriteRenderer _sprite;

    [SerializeField] GameObject _bedCollider;
    [SerializeField] CapsuleCollider2D _collider;
    Vector2 currentY;
    private bool waitingToChange;
    private float exitTimer = 0f;


    private bool clicking = false;
    private bool dragging = false;
    private Rigidbody2D rb;
    private Vector2 currentMoveInput;
    private Vector2 filteredInput;
    private bool _playerTouchingInteractable;
    private Collider2D _touchedObject;
    [SerializeField] private bool _interactableOpened;
    private Iinteractable interactableObject;

    private InputActionMap actionMap;
    private InputAction moveAction;
    private InputAction interactAction;
    private InputAction inventoryAction;
    private InputAction dragAction;
    private InputAction clickAction;


    private ChainConstraint chain;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        chain = GetComponent<ChainConstraint>();

        actionMap = inputActions.FindActionMap("Player");
        moveAction = actionMap.FindAction("Move");
        interactAction = actionMap.FindAction("Interact");
        inventoryAction = actionMap.FindAction("Inventory");
        dragAction = actionMap.FindAction("Drag");
        clickAction = actionMap.FindAction("Click");
    }

    private void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;
        interactAction.started += OnInteract;
        inventoryAction.started += OnInventory;
        dragAction.performed += OnDrag;
        clickAction.canceled += OnClick;
        

        moveAction.Enable();
        interactAction.Enable();
        inventoryAction.Enable();
        dragAction.Enable();
        clickAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;
        interactAction.started -= OnInteract;
        inventoryAction.started -= OnInventory;
        dragAction.performed -= OnDrag;
        clickAction.canceled -= OnClick;


        moveAction.Disable();
        interactAction.Disable();
        inventoryAction.Disable();
        dragAction.Disable();
        clickAction.Disable();
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
        _sprite.flipX = currentMoveInput[0] > 0f;
        if (currentMoveInput != new Vector2(0,0))
        {
            _animator.SetBool("isWalking", true);
        } 
        else
        {
            _animator.SetBool("isWalking", false);
        }
    }

    //triggers when e is pressed and is currently within the range of an interactable object's colliders
    private void OnInteract(InputAction.CallbackContext ctx)
    {
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
    public void ToggleInventory()
    {
        if (_interactableOpened)
        {
            inventory.SetActive(false);
            _interactableOpened = false;
        }
        else
        {
            inventory.SetActive(true);
            _interactableOpened = true;
        }
    }

    private void OnDrag(InputAction.CallbackContext ctx)
    {
        dragging = true;
        Debug.Log("Dragging");
    
    }

    private void OnClick(InputAction.CallbackContext ctx)
    {
        clicking = true;
        Debug.Log("Clicking");
    }

    IEnumerator WaitUntilDrag()
    {
        yield return new WaitForSeconds(.4f);

    }

    void Update()
    {
        if (this.transform.position.y < _bedCollider.transform.position.y)
        {
            //_bedCollider.SetActive(false);
            _sprite.sortingOrder = 6;
        }
        else
        {
            //_bedCollider.SetActive(true);
            _sprite.sortingOrder = 5;
        }

        if(waitingToChange)
        {
            exitTimer += Time.deltaTime; 
            Debug.Log(exitTimer);
            
            if (exitTimer >= 1f)
            {
                Vector2 currentSize = _collider.size;
                currentY = _collider.offset;
                Vector2 newHeight = new Vector2(currentY.x, 0.067f);
                Vector2 newSize = new Vector2(currentSize.x, 9.38f);
                _collider.size = newSize;
                _collider.offset = newHeight;
                exitTimer = 0f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bed"))
        {
            waitingToChange = false;

            Vector2 currentSize = _collider.size;
            currentY = _collider.offset;
            Vector2 newHeight = new Vector2(currentY.x, -3.25f);
            Vector2 newSize = new Vector2(currentSize.x, 2.8f); //2.8
            _collider.size = newSize;
            _collider.offset = newHeight;
        }
        // else
        // {
        //     Vector2 currentSize = _collider.size;
        //     currentY = _collider.offset;
        //     Vector2 newHeight = new Vector2(currentY.x, 0.067f);
        //     Vector2 newSize = new Vector2(currentSize.x, 9.38f);
        //     _collider.size = newSize;
        //     _collider.offset = newHeight;
        // }

    }
    
    void OnCollisionExit2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("bed"))
        {
            waitingToChange = true;
            

            // if (exitTimer >= 1f)
            // {
            //     Vector2 currentSize = _collider.size;
            //     currentY = _collider.offset;
            //     Vector2 newHeight = new Vector2(currentY.x, 0.067f);
            //     Vector2 newSize = new Vector2(currentSize.x, 9.38f);
            //     _collider.size = newSize;
            //     _collider.offset = newHeight;
            //     exitTimer = 0f;
            // }
        }
    }

    
}
