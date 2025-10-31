using UnityEngine;

[ExecuteInEditMode]
public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    public string description;
    public int id;
   
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemSprite;
    }
    
    public void PickUp()
    {
        gameObject.SetActive(false);
    }
}
