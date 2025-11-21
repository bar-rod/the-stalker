using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;
public class LightController : MonoBehaviour, Iinteractable
{
    public float max_time;
    public float time;
    public Timer timer;
    [SerializeField] public float current_flicker_time;

    private bool isOf;

    [SerializeField] private GameObject lightOff;
    [SerializeField] private GameObject lightOn;
    [SerializeField] private GameOver gameOver;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _flickerSound;
    [SerializeField] private AudioSource _switchSound;

    [SerializeField] public Light2D SpotLight2D;
    [SerializeField] public Light2D GlobaLight2D;
    [SerializeField] InputActionAsset playerControls;
    private InputActionMap actionMap;
    private InputAction playerInteract;
    private bool _playerTouchingLightSwitch;
    private float cooldown = 0;
    private float game_over_timer = 20f;
    private bool player_turn_off;


    void Start()
    {
        max_time = timer.time;
        _flickerSound.Play();

        //timer = GetComponentInParent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        time = timer.time;
        // checks if light is on and cooldown is done to have chance for light to turn off
        if (isOf == false && cooldown <= 0)
        {
            randomFlicker(time, max_time);
        }
        // checks if light is off to and gambles for chance of light to turn on
        else if (isOf == true && time > max_time * 0.40 && current_flicker_time <= 0f)
        {
            randomTurnOn(time, max_time);
        }
        // if the current time is in between 20% of max time and 40% of max time then the light turns off at a set time between 15 to 30 seconds
        else if (time > max_time * 0.2 && time < max_time * 0.40 && isOf == true && current_flicker_time <= 0f)
        {
            turnLightsOn();
        }
        //decreases flicker timer
        current_flicker_time -= Time.deltaTime;
      
        // decreases game over timer 
        if (isOf == true)
        {
            game_over_timer -= Time.deltaTime;
        }
        //if player has been in the dark for more than 20 seconds than its game over
        if (game_over_timer <= 0)
        {
            gameOver.ActivateGameOver();

        }
        cooldown -= Time.deltaTime;
    }
    //turns light on and off
    public bool Interact()
    {
        _switchSound.Play();
        Debug.Log("Called Interact() from LightController");
        if (isOf == true && time < max_time * 0.40 )
        {
            Debug.Log("Light Switch turned on");
            if (!player_turn_off)
            {
                cooldown = 15f;
            }
            turnLightsOn();
        }
        else if (isOf == false && time < max_time * 0.40)
        {
            Debug.Log("Light Switch turned off");
            player_turn_off = true;
            turnLightsOff();
        }

        return false;
    }
    public void CloseUI(){
     return;
    }
    // determines if light will turn off by getting a random int between 0 and the current time and checking if the random number 
    // is less than .1% of the max time. 
    // The chance of the light turing off will increase as time decreases.
    public void randomFlicker(float time, float max_time)
    {
        float threshold = max_time * 0.001f;
        float randInt;
        if (time < 0.2 * max_time)
        {
            threshold = 0.5f;
            randInt = Random.Range(0f, 100f);
        }
        else
        {
            randInt = Random.Range(0f, time);
        }
        if (randInt < threshold)
        {
            player_turn_off = false;
            turnLightsOff();

        }
        

    }

    // does the opposite of the previous function. Determines random time for light to turn back on again
    public void randomTurnOn(float time, float max_time)
    {
        float threshold = max_time * 0.35f;
        float randInt = Random.Range(0f, time);
        if (randInt > threshold)
        {
            turnLightsOn();

        }

    }
    //turns the lights on
    private void turnLightsOn()
    {
        SpotLight2D.intensity = 1f;
        GlobaLight2D.intensity = 0.3f;
        isOf = false;
        game_over_timer = 20f;
        
        lightOff.SetActive(false);
        lightOn.SetActive(true);
        _animator.SetBool("isOn", true);
        _flickerSound.Play();
    }
    //turns the lights off
    private void turnLightsOff()
    {
        SpotLight2D.intensity = 0;
        GlobaLight2D.intensity = 0.07f;
        if(time > max_time * 0.2 && time < max_time * 0.40){
        current_flicker_time = Random.Range(15f, 30f);
        }
        else{
            current_flicker_time = Random.Range(0.5f, 1f);
        }
        //flicker_time += 0.05f;
        
        lightOn.SetActive(false);
        lightOff.SetActive(true);
        _animator.SetBool("isOn", false);
        _flickerSound.Stop();

        isOf = true;
    }

}
