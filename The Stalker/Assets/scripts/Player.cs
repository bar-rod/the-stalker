using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] InputActionAsset inputActions;
    [SerializeField] float charSpeed;
    [SerializeField] Rigidbody rb;
    private Vector2 currentMoveInput;

    private InputActionMap actionMap;
    private InputAction moveAction;

    private Vector2 moveInput;

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
        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);
        rb.linearVelocity = direction * charSpeed;
    }
    
    void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
}
