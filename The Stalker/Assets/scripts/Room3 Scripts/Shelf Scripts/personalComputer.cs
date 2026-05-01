using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


public class personalComputer : MonoBehaviour
{
    protected bool isSolved = false;
    protected InventoryManager inventory;
    [SerializeField] Player player;
    [SerializeField] int itemIDRequired;
    [SerializeField] Sprite newSprite; 
    bool hint = false;
    private AudioSource[] audioSources;

    private Image uiImage;

    void Start()
    {
        inventory = FindFirstObjectByType<InventoryManager>();

        uiImage = GetComponent<Image>();
        if (uiImage == null)
        {
            Debug.LogWarning("personalComputer: No Image component found on the GameObject. Cannot change UI sprite.");
        }

        audioSources = GetComponents<AudioSource>();
    }

    // this replaces the interact method of puzzleInteractable
    // you make a button component then connect this method to it
    public void onClick()
    {
        if (isSolved)
            return;

        else
        {
            inventory.ToggleInventory();
        }
    }
    public void useItem(Item item)
    {
        if (item == null)
        {
            hint = true;
            return;
        }
        if (item.id == itemIDRequired)
        {
            Debug.Log(item.name + (" is the correct item"));
            isSolved = true;
            solve();
        }

        else
        {
            hint = true;
            Debug.Log(item.name + (" is not the correct item"));
        }

        if(hint)
        {
            int randomHint = Random.Range(0, audioSources.Length);
            audioSources[randomHint].Play();
            hint = false;
        }
    }

    // If we split this into an abstract class, put this as an overridden function.
    public void solve()
    {
        if (uiImage == null)
        {
            Debug.Log("personalComputer.solve: uiImage is null, cannot set sprite.");
            return;
        }

        if (newSprite == null)
        {
            Debug.Log("personalComputer.solve: newSprite (source Image) is null, cannot set sprite.");
            return;
        }

        uiImage.sprite = newSprite;
    }
}
