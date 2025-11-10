using UnityEngine;

public class CarpetController : MonoBehaviour
{
    [SerializeField] private AudioSource _creakingSound;
    [SerializeField] private bool puzzleUnlocked;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float speed;

    //when player steps on the carpet, sound will play
    void OnTriggerEnter2D(Collider2D collider)
    {
        _creakingSound.Play();
    }

    //when player steps off the carpet, sound will stop
    void OnTriggerExit2D(Collider2D collider)
    {
        _creakingSound.Stop();
    }

    void FixedUpdate()
    {
        if (puzzleUnlocked)
        {
            //when puzzle is completed, set this bool to true and the carpet will be revealed
           transform.position = Vector2.MoveTowards(transform.position, _targetPosition.transform.position, speed * Time.deltaTime);
        }
    }
    
}
