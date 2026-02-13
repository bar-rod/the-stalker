using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    [SerializeField] private Sprite newSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = newSprite;
    }
}