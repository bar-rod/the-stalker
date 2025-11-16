using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject clock;
    [SerializeField] private AudioClip _bgClip;
    [SerializeField] private AudioClip _bgClipFast;
    [SerializeField] private AudioSource _firstTrack;
    [SerializeField] private AudioSource _secondTrack;

    [SerializeField] private LightController _lightControl;
    [SerializeField] private Timer _time;
    private bool hasChangedAudio = false; 
    private bool _track1isPlaying;

    private float time = 20f;
    public void TurnOffClockCanvas()
    {
        clock.SetActive(false);
    }

    void Start()
    {

        _track1isPlaying = true;
        ChangeAudio(_bgClip);

        // _bgNormal.clip = _bgClip;
        // _bgNormal.loop = true;
        // _bgNormal.Play();
    }

    private void ChangeAudio(AudioClip newClip)
    {
        if (!hasChangedAudio)
        {
            hasChangedAudio = true;
            if (_track1isPlaying)
            {
            _secondTrack.clip = newClip;
            _secondTrack.Play();
            _firstTrack.Stop();
            }
            else
            {
            _firstTrack.clip = newClip;
            _firstTrack.Play();
            _secondTrack.Stop();
            }
    
            _track1isPlaying = !_track1isPlaying;
        }
        


        // _bgNormal.clip = _bgClipFast;
        // _bgNormal.loop = true;
        // _bgNormal.Play();
    }

    void Update()
    {
        if(!hasChangedAudio && _time.time <= time * 0.3f)
        {
            hasChangedAudio = false;
            ChangeAudio(_bgClipFast);
            
        }
    }
    
}
