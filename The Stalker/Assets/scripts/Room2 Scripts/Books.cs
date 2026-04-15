using UnityEngine;

public class Books : MonoBehaviour
{
    [SerializeField] private Sprite completed;
    [SerializeField] private BotDoor _door;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private Player player;
    [SerializeField] private GameObject bookshelf;
    [SerializeField] private GameObject spoon;
    [SerializeField] private GameObject spotlight;
    [SerializeField] private GameObject doorcollider;

    public bool solved = false;

    public void Solved()
    {
        solved = true;
        _sprite.sprite = completed;
        player.SetUiOpenFalse();
        bookshelf.SetActive(false);
        _door.PlayerSolved();
        spoon.SetActive(false);
        spotlight.SetActive(true);
        doorcollider.SetActive(true);
    }
}
