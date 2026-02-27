using UnityEngine;

public class DialogueLocator3 : MonoBehaviour
{
    public static DialogueLocator3 Instance { get; private set; }
    public DialogueRoom3 Dialogue3Script { get; private set; }

    private void Awake()
    {
        if (Instance != null & Instance != this)
        {
            Destroy(this);
            return;
        }

        Instance = this;

        GameObject dialogueObj = GameObject.FindWithTag("DialogueSingle");
        Dialogue3Script = dialogueObj.GetComponent<DialogueRoom3>();
    }
}