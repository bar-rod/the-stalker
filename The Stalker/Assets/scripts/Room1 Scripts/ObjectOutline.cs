using UnityEngine;

public class ObjectOutline : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _parentSpriteRenderer;
    private Collider2D _collider;
    [SerializeField] private Material[] _materials;
    private enum MaterialType{Outline = 0, NonOutline = 1}
    public bool isShaderConstructed = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _parentSpriteRenderer = GetComponentInParent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
    public void SetOutlineActive()
    {
        if (isShaderConstructed)
        {
            _parentSpriteRenderer.material = _materials[(int)MaterialType.Outline];
            return;
        }
        _spriteRenderer.enabled = true;
    }

    public void SetOutlineInactive()
    {
        if (isShaderConstructed)
        {
            _parentSpriteRenderer.material = _materials[(int)MaterialType.NonOutline];
            return;
        }
        _spriteRenderer.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetOutlineActive();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SetOutlineInactive();
        }
    }

    public void SetDisable()
    {
        this.enabled = false;
        if (_collider != null)
        {
            _collider.enabled = false;
        }
    }
}
