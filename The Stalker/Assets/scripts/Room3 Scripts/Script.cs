using UnityEngine;
using TMPro;
using System.Collections;

// Now this is a descriptive name for a script!
public class Script : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Toolbox_Inventory interactable;
    [SerializeField] private string textToDisplay;
    [SerializeField] private string altTextToDisplay; // alternate text to display if the player has the key in their inventory

    private bool isDisplaying = false;

    void Update()
    {
        if (interactable.hint && !isDisplaying)
        {
            StartCoroutine(ShowTextForTwoSeconds());
            interactable.hint = false; // reset the hint flag
        }
        if (interactable.hintWKey && !isDisplaying)
        {
            //textToDisplay = altTextToDisplay; // change the text to display the alternate hint
            StartCoroutine(ShowTextForTwoSeconds());
            interactable.hintWKey = false; // reset the hint flag
        }
    }

    private IEnumerator ShowTextForTwoSeconds()
    {
        isDisplaying = true;

        //text.SetActive(true);
        if(interactable.hintWKey)
        {
            text.text = altTextToDisplay;
        }
        else if(!interactable.toolBoxOpen && interactable.hint)
        {
            text.text = textToDisplay;
        }

        yield return new WaitForSeconds(3f);
        
        text.text = "";
        isDisplaying = false;
    }
}