using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    //edit max time in the inspector of gameobject that holds the script
    public float time = 5f;
    public bool runnin = false;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private Slider healthBar;

    private float maxTime;
    private void Start()
    {
        maxTime = time;
        runnin = true;

        if (healthBar != null)
        {
            healthBar.maxValue = maxTime;
            healthBar.value = maxTime;
        }
    }

    void Update()
    {
        if (runnin)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                //Debug.Log(time);

                if (healthBar != null)
                    healthBar.value = time;
            }
            else
            {
                //Debug.Log("time ran out");
                time = 0;
                runnin = false;
                gameOver.SetActive(true);
            }
        }
    }
}
