using UnityEngine;

public class LocatorDialogue : MonoBehaviour
{
    public static LocatorDialogue Instance {get; private set;}
    public Dialogue DialogueScript {get; private set;}

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject dialogueObj = GameObject.FindWithTag("DialogueSingle");
        DialogueScript = dialogueObj.GetComponent<Dialogue>();
    }
}
