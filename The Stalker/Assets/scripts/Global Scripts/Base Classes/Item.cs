using System.Data;
using UnityEngine;

[ExecuteInEditMode]
public class Item : MonoBehaviour
{
    public string itemName;
    public Sprite itemSprite;
    public string description;
    public int id;
    public bool initiallyActive;

    private AudioSource _collectSound;

   
    protected virtual void Start()
    {
        if (initiallyActive) gameObject.SetActive(true);
        GetComponent<SpriteRenderer>().sprite = itemSprite;

        _collectSound = GetComponent<AudioSource>();
    }

    public virtual void Interact(Collider2D other)
    {
        Pickup();
    }
    public virtual void SetVisible()
    {
        gameObject.SetActive(true);
    }
    public override string ToString()
    {
        return itemName + "\nID Number: " + id + "\n" + description + "\n\nInitially Active?: " + initiallyActive + "\nSprite: " + itemSprite;
    }
    
    public void Pickup()
    {
        _collectSound.Play();

        gameObject.SetActive(false);

        GameManager.ItemPickedUp.Invoke(this);
    }

    public virtual void UseItem()
    {
        Debug.Log(this.name + " was used!");
    }
}
