using UnityEngine;

public class BotDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    //[SerializeField] private GameObject collider;

    [SerializeField] private Books _books;
    [SerializeField] private CarpetController _controller;
    public void PlayerSolved()
    {
        _animator.SetBool("player", true);
        
    }

    private void Update()
    {
        if (_books.solved && _controller.carpetUp)
        {
            GetComponentInChildren<EdgeCollider2D>().enabled = true;
        }
    }
}