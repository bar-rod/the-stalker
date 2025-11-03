using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public bool trapDoorSliding = false;
    [SerializeField] private float speed;

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
        if (trapDoorSliding)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (transform.position == targetPosition)
        {
            trapDoorSliding = false;
        }
    }

    //Used in the ClockManager's inspector for Unity Events to let the trapdoor start moving.
    public void SetMovingTrue()
    {
        trapDoorSliding = true;
    }
}
