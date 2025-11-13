using UnityEngine;

public class PlayerConnector : MonoBehaviour
{
    public Transform player;
    private TargetJoint2D joint;
    [SerializeField] private Vector3 offset;
    void Start()
    {
        joint = GetComponent<TargetJoint2D>();
        joint.enabled = true;
        joint.anchor = Vector2.zero; 
        joint.autoConfigureTarget = false;
    }

    void FixedUpdate()
    {
        joint.target = player.position + offset;
    }
}