using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Dialogue : MonoBehaviour
{
    public string[] beginStalkerLines;
    public string[] endStalkerLines;
    private int i;
    [SerializeField] private TMP_Text subtite_text; 
    [SerializeField] private TMP_Text elisa_text; 
    [SerializeField] private GameObject dialoguebox;
    [SerializeField] private GameObject elisa_dialoguebox;

    [SerializeField] private TimelineAsset openStalker;
    [SerializeField] private TimelineAsset endStalker;
    

    private PlayableDirector director; // for stalker audio
    private AudioSource elisaAudio;

    private string[] lines;


    //needs to be set up with the inventory


    //to reference a variable in another script
    //LocatorDialogue.Instance.DialogueScript.VARIABLE/FUNCTIONNAME
    //LocatorDialogue.Instance.DialogueScript.ShowElisaText("I saw the Clueboard");
    
    public bool CollectedPocketWatch {get; set;}
    public bool SawClueBoard {get; set;}
    public bool UnlockedKey {get; set;}


    /*
    For pocket watch, Interactable UI checks if player opened the clueboard and sets SawClueBoard to true;
        //to make it so that player saw the clue board before collected the pocket watch
            if (other.name == "ClueBoard")
            {
                LocatorDialogue.Instance.DialogueScript.SawClueBoard = true;
            }
    When player collects pocket watch, if item is pocket watch, then it calls in ShowElisaText 
        if sawclueboard is true ShowElisaText("I saw this before...)
        else ShowElisaText("What is this")

    //For the future, if its likely that other rooms will have other audios,
    // not ideal to have all lines together etc, so i should plan to make a inheritiance
    in DeskPapers script: // might likely need to make a separate script per room!
    //but that is mainly for the stalker lines that gets all built up 
        //to have elisa say smth
        if (this.name == "Calendar")
        {
            LocatorDialogue.Instance.DialogueScript.ShowElisaText("Oh…that’s my birthday.");
        }
        else if (this.name == "ResignationLetter")
        {
            LocatorDialogue.Instance.DialogueScript.ShowElisaText("A resignation letter?");
        }
    
    */
    
    

    

    /* Beginning lines
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

    Ending lines for room 1

    Wonderful job Elisa. 
    That wasn’t so hard, was it? 
    I knew you wouldn’t disappoint me. 
    We aren’t quite done yet, 
    but because you’ve been so good I think I’ll give you a hint for the next room. 
    You’re going to pull three books from the shelf, got that? 
    Three books. 
    Of course, it’s up to you to figure out the right ones. 
    Good luck. 



    */


    void Start()
    {
        i = 0;
        dialoguebox.SetActive(true);
        elisa_dialoguebox.SetActive(false);
        director = GetComponent<PlayableDirector>();
        elisaAudio = GetComponent<AudioSource>();

        //move if needed
        director.Play();

        lines = beginStalkerLines;

        CollectedPocketWatch = false;
        SawClueBoard = false;
        UnlockedKey = false;

        //through this way, there seems to be a delay :(
        //introAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (i < lines.Length)
        {
            subtite_text.text = lines[i];
            //player can't move
        }
        else
        {
            dialoguebox.SetActive(false);
            director.Stop();
            //play can move again
        }

        //if player clicked skip, then just make i greater than length

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

    public void ChangeTimeline()
    {
        if (UnlockedKey)
        {
            director.playableAsset = endStalker; 
            //play here? 
        }
    }

    public void SkipStalkerDialogue()
    {
        i = lines.Length + 1;
    }
}
