using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour{
    public float time = 300f;
    public bool runnin = false;
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
            }
            else
            {
                Debug.Log("time ran out");
                time = 0;
                runnin = false;
                gameObject.GetComponent<GameOver>().ActivateGameOver();
            }
        }
    }
}
