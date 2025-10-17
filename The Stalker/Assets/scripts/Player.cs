using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] float charSpeed;
    [SerializeField] Rigidbody2D rb;
    private Vector2 currentMoveInput;

    private InputActionMap actionMap;
    private InputAction moveAction;

    void Awake()
    {
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
        rb.linearVelocity = new Vector2(currentMoveInput.x * charSpeed, currentMoveInput.y * charSpeed);
    }
    
    void OnMove(InputAction.CallbackContext ctx)
    {
        currentMoveInput = ctx.ReadValue<Vector2>();
    }
}
