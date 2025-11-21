using UnityEngine;

public class Room2Manager : MonoBehaviour
{
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;
    [SerializeField] private GameObject _player;

    void Update()
    {
        Vector3 pos = _player.transform.position;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        _player.transform.position = pos;
    }
}
