using UnityEngine;

public class Desk : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer _sprite;

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < player.transform.position.y)
        {
            _sprite.sortingOrder = 4;
        }
        else
        {
            _sprite.sortingOrder = 7;
        }
    }
}
