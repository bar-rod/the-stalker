using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject reply;
    [SerializeField] private GameObject replyHigh;
    [SerializeField] private StartButton reply1;
    [SerializeField] private StartButton replyHigh2;
    [SerializeField] private List<GameObject> frames = new List<GameObject>();
    [SerializeField] private AudioSource _audioS;
    [SerializeField] private AudioClip clip;

    private float timer = 0f;
    private bool highlight = true;
    private int i = 0;

    void Start()
    {
        _audioS.clip = clip;
        _audioS.Play();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f && !reply1.off && !replyHigh2.off)
        {
            if(highlight)
            {
                replyHigh.SetActive(true);
                reply.SetActive(false);
                highlight = false;
            }
            else
            {
                reply.SetActive(true);
                replyHigh.SetActive(false);
                highlight = true;
            }

            timer = 0f;
        }

        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            i += 1;
            if(i < frames.Count)
            {
                frames[i].SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
