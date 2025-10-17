using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    private InputActionMap actionMap;
    private InputAction resetAction;

    private void Awake()
    {
        actionMap = actionAsset.FindActionMap("Player");
        resetAction = actionMap.FindAction("Reset");
    }
    private void Update()
    {
        
    }

    private void OnEnable()
    {
        resetAction.performed += OnReset;
        resetAction.canceled += OnReset;

        resetAction.Enable();
    }

    private void OnDisable()
    {
        resetAction.performed -= OnReset;
        resetAction.canceled -= OnReset;

        resetAction.Disable();
    }

    private void OnReset(InputAction.CallbackContext ctx)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }
}
