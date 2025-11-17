using UnityEngine;

public class JewelryBoxManagerScript : MonoBehaviour
{
    [Tooltip("Assign the JewelryBox prefab here.")]
    public GameObject jewelryBoxPrefab;

    [Tooltip("Assign the Location Pool (empty GameObject named 'Locations').")]
    public Transform locationPool;

    [SerializeField] private GameObject _pocketWatch;
    [SerializeField] private Sprite _openBoxSprite;

    private SpriteRenderer _spriterenderer;
    private GameObject box_instance;

    void Start()
    {
        if (jewelryBoxPrefab == null)
        {
            Debug.LogError("JewelryBoxPrefab not assigned.");
            return;
        }

        // If not assigned in the Inspector, try to find the empty GameObject named "Locations"
        if (locationPool == null)
        {
            var found = GameObject.Find("Locations");
            if (found != null)
                locationPool = found.transform;
        }

        if (locationPool == null)
        {
            Debug.LogError("Location Pool not assigned and no GameObject named 'Locations' found.");
            return;
        }

        int childCount = locationPool.childCount;
        if (childCount == 0)
        {
            Debug.LogError("No spawn locations found under Location Pool.");
            return;
        }

        int randomIndex = Random.Range(0, childCount);
        Transform spawnPoint = locationPool.GetChild(randomIndex);

        box_instance = Instantiate(jewelryBoxPrefab, spawnPoint.position, spawnPoint.rotation);
        _pocketWatch.transform.position = spawnPoint.position;
        _pocketWatch.transform.rotation = spawnPoint.rotation;
    }

    void FixedUpdate()
    {
        if (!_pocketWatch.activeInHierarchy)
        {
            _spriterenderer = box_instance.GetComponent<SpriteRenderer>();
            _spriterenderer.sprite = _openBoxSprite;
        }
    }
}