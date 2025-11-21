using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    [SerializeField] private GameObject reply;
    [SerializeField] private GameObject replyHigh;

    private float timer = 0f;
    private bool highlight = true;
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 1f)
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
    }
}
