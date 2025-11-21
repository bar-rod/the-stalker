using UnityEngine;

public class Desk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private GameObject desk;

    // Update is called once per frame
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
