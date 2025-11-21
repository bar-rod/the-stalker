using UnityEngine;


public class OpenDrawer : MonoBehaviour
{
    [SerializeField] private GameObject cabinet;
    [SerializeField] private GameObject Drawer;
     [SerializeField] private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=GameObject.Find("Player").GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cabinet.GetComponent<Keypad>().drawerOpened == true){
            Drawer.SetActive(true);
            gameObject.GetComponent<InteractableUI>().Interact();
            player.SetUiOpenFalse();
            gameObject.GetComponent<InteractableUI>().enabled =false;
            gameObject.GetComponent<Collider2D>().enabled=false;
            cabinet.GetComponent<Keypad>().drawerOpened = false;

        }
    }
}
