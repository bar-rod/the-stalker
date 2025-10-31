// This script reads input from the "Inventory" Input Action, and toggles the referenced Inventory Canvas on/off.

using UnityEngine;
using UnityEngine.InputSystem;
public class OpenInventory : MonoBehaviour
{
    [SerializeField] InputActionAsset playerControls;
    [SerializeField] GameObject inventory;

    private InputActionMap actionMap;
    private InputAction playerInventory;

    private bool inventoryIsOpen;

    void Awake()
    {
        actionMap = playerControls.FindActionMap("Player");
        playerInventory = actionMap.FindAction("Inventory");
        inventoryIsOpen = false;
    }

    private void OnEnable()
    {
        playerInventory.started += Interact;
        playerInventory.Enable();
    }

    private void OnDisable()
    {
        playerInventory.started -= Interact;
        playerInventory.Disable();
    }

    private void Interact(InputAction.CallbackContext context)
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
    }
}
