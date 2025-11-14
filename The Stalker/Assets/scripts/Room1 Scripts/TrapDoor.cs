using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public bool trapDoorSliding = false;
    private bool trapDoorMoving = false; //for audio
    [SerializeField] private float speed;
    [SerializeField] private GameObject key;

    [SerializeField] private SpriteRenderer _door;
    [SerializeField] private AudioSource _openDoorSound;


    [Header("The transform of the target location")]
    [SerializeField] private Transform target;
    private Vector3 targetPosition;
    private void Start()
    {
        targetPosition = target.position;

    }


    //Set the object's Vector3 to move towards a target Vector3 at the speed of speed/frame
    void FixedUpdate()
    {
        if (trapDoorSliding && transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            
            //audio
            if (!trapDoorMoving)
            {
                trapDoorMoving = true;
                _openDoorSound.Play();
            }
            
        }

        if (transform.position == targetPosition)
        {
            trapDoorSliding = false;
            trapDoorMoving = false;
            _openDoorSound.Stop();
        }

    }

    //Used in the ClockManager's inspector for Unity Events to let the trapdoor start moving.
    public void SetMovingTrue()
    {
        trapDoorSliding = true;
        _door.sortingOrder = 2;
        key.SetActive(true);
    }
}
