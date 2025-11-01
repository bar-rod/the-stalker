using UnityEngine;

public interface Iinteractable
{
    void Interact(Collider2D other);
    void CloseUI(Collider2D other);
}