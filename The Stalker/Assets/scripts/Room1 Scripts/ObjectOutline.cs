using UnityEngine;

public class ObjectOutline : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private SpriteRenderer _parentSpriteRenderer;
    [SerializeField] private Material[] _materials;
    private enum MaterialType{Outline = 0, NonOutline = 1}
    public bool isShaderConstructed = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _parentSpriteRenderer = GetComponentInParent<SpriteRenderer>();
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
}
