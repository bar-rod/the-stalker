using UnityEngine;

public class Clock : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject clock;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player!");
            clock.SetActive(true);
        }
            
        //Debug.Log("Collided with: " + other.tag);
    }
}
