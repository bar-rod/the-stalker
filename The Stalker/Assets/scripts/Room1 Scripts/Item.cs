using UnityEngine;
public class Item : MonoBehaviour, Iinteractable
{
    public string itemName;
    public Sprite itemSprite;
    public string description;
    public int id;
   
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }

    public void Interact()
    {
        gameObject.SetActive(false);
    }
    
}
