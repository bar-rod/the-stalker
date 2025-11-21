using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundFXObject;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    
    //Call this from using the Singleton SoundManager game object in the scene. Should specify the start time of the
    // audio clip, and the live time of the audio clip from the parameter "time". Auto destroys itself once
    // audio clip is finished our live time is up. 
    public void PlaySoundEffectClip(AudioClip audioClip, Transform spawnTransform, float volume, float time, float startTime)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;
        audioSource.time = startTime;

        audioSource.Play();

        float clipLength = audioSource.clip.length;
        if (time <= 0)
        {
            Destroy(audioSource.gameObject, clipLength);
        }
        else
        {
            Destroy(audioSource.gameObject, time);
        }


    }
}