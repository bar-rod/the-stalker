using UnityEngine;

public class SpriteOrder : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject player;
    [SerializeField] private SpriteRenderer _sprite;
    [SerializeField] private GameObject car;

    // Update is called once per frame
    void Update()
    {
        if (car.transform.position.y < player.transform.position.y)
        {
            _sprite.sortingOrder = 4;
        }
        else
        {
            _sprite.sortingOrder = 7;
        }
    }
}
