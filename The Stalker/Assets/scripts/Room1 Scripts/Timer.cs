using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    public float time = 5f;
    public bool runnin = false;
    [SerializeField] private GameObject gameOver;
    private void Start()
    {
        runnin = true;
    }

    void Update()
    {
        if (runnin)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                //Debug.Log(time);
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
