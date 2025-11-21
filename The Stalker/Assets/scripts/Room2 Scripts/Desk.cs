using UnityEngine;

public class Desk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject player;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private GameObject desk;

    // Update is called once per frame
    void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (desk.transform.position.y < player.transform.position.y)
        {
            _sprite.sortingOrder = 3;
        }
        else
        {
            _sprite.sortingOrder = 7;
        }
    }
}
