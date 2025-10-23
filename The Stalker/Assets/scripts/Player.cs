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
    private Rigidbody2D rb;
    private Vector2 currentMoveInput;
    private Vector2 filteredInput;

    private InputActionMap actionMap;
    private InputAction moveAction;

    private ChainConstraint chain;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        chain = GetComponent<ChainConstraint>();

        actionMap = inputActions.FindActionMap("Player");
        moveAction = actionMap.FindAction("Move");
    }

    private void OnEnable()
    {
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        moveAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.performed -= OnMove;
        moveAction.canceled -= OnMove;

        moveAction.Disable();
    }

    void FixedUpdate()
    {
        Vector2 proposedVelocity = new Vector2(currentMoveInput.x * charSpeed, currentMoveInput.y * charSpeed);
        rb.linearVelocity = chain.FilterMovement(proposedVelocity) * charSpeed;
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        currentMoveInput = ctx.ReadValue<Vector2>().normalized;
    }
    
    // void OnTriggerEnter2D(Collider2D collider)
    // {
    //     Debug.Log("Player can open clue: " + collider.gameObject.name);
    // }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Player can open clue: " + other.gameObject.name);
    }
}
