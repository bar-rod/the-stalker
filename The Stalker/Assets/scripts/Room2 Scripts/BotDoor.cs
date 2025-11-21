using UnityEngine;

public class BotDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void OnTriggerEnter2D(Collider2D other)
    {
        _animator.SetBool("player", true);
    }
}