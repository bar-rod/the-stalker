using UnityEngine;

public class ChainConstraint : MonoBehaviour
{
    [Tooltip("\"True\" if still chained, \"False\" to free movement")]
    [SerializeField]
    private bool isChained = true;
    [Header("Ellipse Dimensions")] // i had to do ellipse math for this shit. please kill me.
    [SerializeField] public float radiusX = 0.75f; 
    [SerializeField] public float radiusY = 0.5f; 
    private Vector2 currentRadius;
    public GameObject anchor;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // call this function to turn off the chain logic
    // doesn't affect visual chain yet (to be implemented)
    public void BreakChain()
    {
        isChained = false;
        enabled = false;
    }

    // called by player movement
    // modifies movement direction vector
    // if player reaches or passes maxRadius, sets the movement direction vector to 0
    public Vector2 FilterMovement(Vector2 desiredVelocity)
    {
        if (!isChained) return desiredVelocity;

        Vector2 offset = rb.position - (Vector2)anchor.transform.position;
        Vector2 proposed = offset + desiredVelocity;

        // convert to unit circle space
        Vector2 scaled = new Vector2(proposed.x / radiusX, proposed.y / radiusY);
        float mag = scaled.magnitude;

        if (mag > 1f) // i.e. if the player is outside the unit circle
        {
            scaled /= mag;
            Vector2 clamped = new Vector2(scaled.x * radiusX, scaled.y * radiusY);
            desiredVelocity = clamped - offset;
        }

        return desiredVelocity;
    }

    // this part is just a safety net, in case the player somehow lands outside the ellipse
    public Vector2 ClampPosition(Vector2 position)
    {
        if (!isChained) return position;

        Vector2 offset = position - (Vector2)anchor.transform.position;
        float ratio = (offset.x * offset.x) / (radiusX * radiusX) + (offset.y * offset.y) / (radiusY * radiusY);

        if (ratio > 1f)
        {
            float scale = 1f / Mathf.Sqrt(ratio);
            offset *= scale;
        }

        return (Vector2)anchor.transform.position + offset;
    }
}