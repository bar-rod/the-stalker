using UnityEngine;

public class BotDoor : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    //[SerializeField] private GameObject collider;

    public void PlayerSolved()
    {
        _animator.SetBool("player", true);
        //collider.SetActive(true);
    }
}