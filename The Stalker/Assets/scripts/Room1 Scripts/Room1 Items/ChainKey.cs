using UnityEngine;

public class ChainKey : MonoBehaviour, Iinteractable // Doesn't inherit from Item because it never actually gets added to inv
{

    public ChainConstraint chainConstraint;
    public TargetJoint2D chainConnector;
    [SerializeField] private LightController _light;
    [SerializeField] private Timer time;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject exitDoorLight;
    public bool Interact() 
    {
        // Debug.Log("using chain key");

        chainConstraint.BreakChain();
        LocatorDialogue.Instance.DialogueScript.PlayStalkerEndLines();
        chainConnector.enabled = false;

        _light.turnLightsOff();
        _light.enabled = false;

        exitDoorLight.SetActive(true);

        time.enabled = false;
        healthBar.SetActive(false);

        gameObject.SetActive(false);
        return false; // UI is not open, so set to false
    }
}
