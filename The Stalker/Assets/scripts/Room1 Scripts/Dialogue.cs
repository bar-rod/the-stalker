using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public string[] lines;
    private int i;
    [SerializeField] private TMP_Text subtite_text; 
    [SerializeField] private 
    /*
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
            
        }
    }

    public void NextLine()
    {
        Debug.Log("Next line pls");
        i++;
    }
}
