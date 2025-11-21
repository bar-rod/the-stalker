using UnityEngine;
using UnityEngine.UI;

public class soundBar : MonoBehaviour
{
    [SerializeField] float currentVolume;
    [SerializeField] private int sampleDataLength = 1024;
    private float[] samples;
    [SerializeField] private float volume;
    private const float maxVolume = 0.95f;
    [SerializeField] private float repeatSoundIncreaseRate = 0.3f;
    [SerializeField] private float lowVolumeThreshold = 0.5f;
    [SerializeField] private float decayRate = 0.1f;
    [SerializeField] private GameObject gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentVolume = this.GetComponent<Image>().fillAmount;
        samples = new float[sampleDataLength];
    }

    // Update is called once per frame
    void Update()
    {
        currentVolume = GetComponent<Image>().fillAmount;

        // Get audio data using RMS
        AudioListener.GetOutputData(samples, 0);
        float sum = 0f;
        foreach (float f in samples)
            sum += f * f;

        // We use 0.6f as max volume to prevent insta death
        volume = Mathf.Clamp(Mathf.Sqrt(sum / sampleDataLength), 0, 0.6f);
        
        if(volume < 0.01f)
            currentVolume -= decayRate * Time.deltaTime;

        volume *= 10f; 

        // Set current volume to latest volume if below threshold
        if (currentVolume <= volume * lowVolumeThreshold)
            currentVolume = volume;

        // Increase current volume if above threshold
        else if(currentVolume >= volume * lowVolumeThreshold)
            currentVolume += volume * repeatSoundIncreaseRate * Time.deltaTime;

        if(currentVolume > maxVolume)
            gameOver.SetActive(true);


        this.GetComponent<Image>().fillAmount = Mathf.Clamp(currentVolume, 0f, 1f);
    }
}
