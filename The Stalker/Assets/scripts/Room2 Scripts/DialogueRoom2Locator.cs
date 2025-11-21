using UnityEngine;

public class LocatorDialogue2 : MonoBehaviour
{
    public static LocatorDialogue2 Instance {get; private set;}
    public DialogueRoom2 Dialogue2Script {get; private set;}

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject dialogueObj = GameObject.FindWithTag("DialogueSingle");
        Dialogue2Script = dialogueObj.GetComponent<DialogueRoom2>();
    }
}