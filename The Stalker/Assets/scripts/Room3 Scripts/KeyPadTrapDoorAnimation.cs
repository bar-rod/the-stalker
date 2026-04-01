using UnityEngine;

public class KeyPadTrapDoorAnimation : MonoBehaviour
{
    [SerializeField] private GameObject keypad;    
    [SerializeField] private TrapDoor trapDoorScript;

    void Update()
    {
        if(trapDoorScript.trapDoorSliding == true)
        {
            keypad.SetActive(false);
        }
    }

}
