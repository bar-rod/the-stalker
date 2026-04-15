using UnityEngine;

public class Trunk : PuzzleInteractable
{

    [SerializeField] private Canvas trunkCanvas;
    public AudioSource _trunkOpenedSound;

    void Start()
    {
        base.Start();

        trunkCanvas.gameObject.SetActive(false);
    }

    public override bool Interact()
    {
        Debug.Log("car trunk interact");
        if (trunkCanvas.gameObject.activeSelf)
        {
            Debug.Log("open canvas");
            CloseCanvas();
        }
        else
        {
            Debug.Log("close canvas");
            OpenCanvas();
        }
        return false;
    }

    public override void UseItem(Item item)
    {
        return;
    }

    private void OpenCanvas()
    {
        _trunkOpenedSound.Play();
        trunkCanvas.gameObject.SetActive(true);
    }

    private void CloseCanvas()
    {
        trunkCanvas.gameObject.SetActive(false);
    }
}
