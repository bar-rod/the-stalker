using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Playables;

public class Dialogue : MonoBehaviour
{
    public string[] lines;
    public string[] elisa_lines;
    private int i;
    [SerializeField] private TMP_Text subtite_text; 
    [SerializeField] private TMP_Text elisa_text; 
    [SerializeField] private GameObject dialoguebox;
    [SerializeField] private GameObject elisa_dialoguebox;
    private PlayableDirector director;

    //needs to be set up with the inventory


    //to reference a variable in another script
    //LocatorDialogue.Instance.DialogueScript.VARIABLE/FUNCTIONNAME
    //LocatorDialogue.Instance.DialogueScript.ShowElisaText("I saw the Clueboard");
    
    public bool CollectedPocketWatch {get; set;}
    public bool SawClueBoard {get; set;}


    /*
    For pocket watch, Interactable UI checks if player opened the clueboard and sets SawClueBoard to true;
    WHen player collects pocket watch, if item is pocket watch, then it calls in ShowElisaText 
        if sawclueboard is true ShowElisaText("I saw this before...)
        else ShowElisaText("What is this")
    */
    
    

    //private AudioSource introAudio;

    /*
    For room 1
    Good morning, Elisa. 
    Did you sleep well? 
    Nonono, don’t struggle.
    You’ll hurt yourself… 
    There, that’s better. 
    Do you like it? 
    It’s all for you. 
    Those other escape rooms were getting too easy.
    I knew you needed a challenge. 
    That’s why you’re chained up. 
    You’d just walk out otherwise, and that’s no fun. 
    Don’t worry.
    there’s a key to free yourself in there somewhere. 
    All you have to do is find it. 
    And one more thing. 
    If you take too long to get out, 
    I have to kill you. 
    I really don’t want to resort to something so messy, 
    but if you aren’t the girl I think you are… 
    No. 
    I know who you are, Elisa. 
    You’ll be fine. 
    Bye for now, 
    I’ll be watching. 
    */
    void Start()
    {
        i = 0;
        dialoguebox.SetActive(true);
        elisa_dialoguebox.SetActive(false);
        director = GetComponent<PlayableDirector>();
        //introAudio = GetComponent<AudioSource>();
        director.Play();

        CollectedPocketWatch = false;
        SawClueBoard = false;

        //through this way, there seems to be a delay :(
        //introAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (i < lines.Length)
        {
            subtite_text.text = lines[i];
        }
        else
        {
            dialoguebox.SetActive(false);
        }

        if (SawClueBoard)
        {
            //Debug.Log("I saw the Clueboard");
        }
    }

    public void NextLine()
    {
        //Debug.Log("Next line pls");
        i++;
    }


    //keeps the dialogue box open for a few seconds and then removes it
    IEnumerator KeepBoxVisible()
    {
        yield return new WaitForSeconds(5);
        elisa_dialoguebox.SetActive(false);
    }
    public void ShowElisaText(string dialogue)
    {
        //if there's going to be audio/voice over, replace with audioclip length 
        // (probably need to put it in the inspector of the other item)

        //sets the text to the corresponding text
        elisa_text.text = dialogue;

        //need to add a set audio source and play if needed

        //makes dialogue box with text appear
        elisa_dialoguebox.SetActive(true);

        //keeps it open for a while
        StartCoroutine(KeepBoxVisible());
        

    }
}
