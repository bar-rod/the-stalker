using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject clock;
    [SerializeField] private AudioClip _bgClip;
    [SerializeField] private AudioClip _bgClipFast;
    [SerializeField] private AudioSource _bgNormal;
    [SerializeField] private LightController _lightControl;
    [SerializeField] private Timer _time;
    private bool hasChangedAudio = false; 

    private float time = 300f;
    public void TurnOffClockCanvas()
    {
        clock.SetActive(false);
    }

    void Start()
    {
        _bgNormal.clip = _bgClip;
        _bgNormal.loop = true;
        _bgNormal.Play();
    }

    private void ChangeAudio()
    {
        _bgNormal.clip = _bgClipFast;
        _bgNormal.loop = true;
        _bgNormal.Play();
    }

    void Update()
    {
        if(!hasChangedAudio && _time.time <= time * 0.3f)
        {
            ChangeAudio();
            hasChangedAudio = true;
        }
    }
    
}
