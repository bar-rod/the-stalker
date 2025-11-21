using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueRoom2 : MonoBehaviour
{

    //temporary script since theres not much for room 2 rn
     public AudioClip[] elisaAudioClips;

     [SerializeField] private TMP_Text elisa_text; 
     [SerializeField] private GameObject elisa_dialoguebox;
      private AudioSource elisaAudio;

       void Start()
    {
        elisa_dialoguebox.SetActive(false);
        elisaAudio = GetComponent<AudioSource>();
    }

    IEnumerator KeepBoxVisible(float sec)
    {
        
        yield return new WaitForSeconds(sec);
        elisa_dialoguebox.SetActive(false);
    }
    public void ShowElisaText(string dialogue, int audioIndex)
    {
        //if there's going to be audio/voice over, replace with audioclip length 
        //Audioclip = elisaAudioClips[audioIndex]

        //sets the audio to the corresponding audio
        elisaAudio.clip = elisaAudioClips[audioIndex];
        elisaAudio.Play();
        //sets the text to the corresponding text
        elisa_text.text = dialogue;

        //play elisa audio line
        
        //makes dialogue box with text appear
        elisa_dialoguebox.SetActive(true);
        //keeps textbox open for a while
        StartCoroutine(KeepBoxVisible(elisaAudio.clip.length));
        

    }
}
