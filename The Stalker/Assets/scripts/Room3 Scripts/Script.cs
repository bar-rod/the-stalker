using UnityEngine;
using TMPro;
using System.Collections;

public class Script : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private Toolbox_Inventory interactable;
    [SerializeField] private string textToDisplay;

    private bool isDisplaying = false;

    void Update()
    {
        if (interactable.hint && !isDisplaying)
        {
            StartCoroutine(ShowTextForTwoSeconds());
            interactable.hint = false; // reset the hint flag
        }
    }

    private IEnumerator ShowTextForTwoSeconds()
    {
        isDisplaying = true;

        //text.SetActive(true);
        text.text = textToDisplay;
        yield return new WaitForSeconds(3f);

        text.text = "";
        isDisplaying = false;
    }
}