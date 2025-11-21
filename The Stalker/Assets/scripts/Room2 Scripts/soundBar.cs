using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class soundBar : MonoBehaviour
{
    [SerializeField] float currentVolume;
    [SerializeField] private int sampleDataLength = 512;
    private float[] samples;
    [SerializeField] private float volume;
    [SerializeField] private const float maxVolume = 0.95f;
    [SerializeField] private float repeatSoundIncreaseRate = .05f;
    [SerializeField] private float lowVolumeThreshold = 0.1f;
    [SerializeField] private float decayRate = 0.01f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentVolume = this.GetComponent<Image>().fillAmount;
        samples = new float[sampleDataLength];
    }

    // Update is called once per frame
    void Update()
    {
        // Get audio data
        AudioListener.GetOutputData(samples, 0);

        // Use RMS to get average volume
        float sum = 0f;
        foreach (float f in samples)
            sum += f * f;

        volume = Mathf.Sqrt(sum / sampleDataLength);

        // a given sound has a set volume level, but repeated sounds of the same volume will make the bar go higher
        if (currentVolume < volume * lowVolumeThreshold)
            currentVolume = volume;
        else if (currentVolume < maxVolume)
            currentVolume+= volume * repeatSoundIncreaseRate;
        else if (currentVolume >= maxVolume)
            // game over

        currentVolume -= decayRate;
        this.GetComponent<Image>().fillAmount = currentVolume;
    }
}
