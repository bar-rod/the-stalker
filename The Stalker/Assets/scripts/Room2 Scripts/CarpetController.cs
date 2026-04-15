using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarpetController : MonoBehaviour
{
    [SerializeField] private AudioSource _creakingSound;
    [SerializeField] private bool puzzleUnlocked;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float speed;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _trapDoor;
    [SerializeField] private GameObject carpet;
    [SerializeField] private GameObject spoon;
    [SerializeField] private GameObject collider;
    private bool playerOnCarpet = false;

    public bool carpetUp = false;

    //when player steps on the carpet, sound will play
    void OnTriggerEnter2D(Collider2D collider)
    {
        _creakingSound.Play();
        playerOnCarpet = true;
    }

    //when player steps off the carpet, sound will stop
    void OnTriggerExit2D(Collider2D collider)
    {
        _creakingSound.Stop();
        playerOnCarpet = false;
    }

    void FixedUpdate()
    {
        if (puzzleUnlocked)
        {
            //when puzzle is completed, set this bool to true and the carpet will be revealed
           //transform.position = Vector2.MoveTowards(transform.position, _targetPosition.transform.position, speed * Time.deltaTime);
        }
    }

    void Update()
    {
        if(playerOnCarpet && Keyboard.current.eKey.wasPressedThisFrame)
        {
            carpet.SetActive(false);
            SetSolved();
            _trapDoor.SetActive(true);
            spoon.SetActive(true);
            carpetUp = true;
        }
    }

    public void SetSolved()
    {
        //puzzleUnlocked = true;
        _animator.SetBool("solved", true);
    }

}
