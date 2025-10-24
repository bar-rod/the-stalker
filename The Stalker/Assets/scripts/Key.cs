using Unity.VisualScripting;
using UnityEngine;

/***********************************************
 * Planned Implementation details 10/23/25 (TODOs)
 * 1. ~~Key relies on a publically available 
 *      function to become active.~~
 * 2. On collision, key is picked up by player
 *      and enters their inventory.
 * 3. Inventory can be viewed by player?
 *      Separate object/script obviously.
 *      Door checks presence of key in inventory.
 ***********************************************/

public class Key : MonoBehaviour
{
    // This is set to true for debug purposes.
    // This is public for ease of use
    [SerializeField] public bool showKey = true;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // key does not become visible until puzzle is done.
        gameObject.SetActive(showKey);
    }

    // Allow player to pick up the key
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        // TODO: Add key to player inventory
        if(collision.gameObject.name == "Player")
            Destroy(gameObject);    // TODO: Change this to key.hightlight, then prompt player to pickup?
            
    }

   
}
