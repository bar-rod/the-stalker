using UnityEngine;
using TMPro;
using System.Data;
using UnityEngine.InputSystem;
public class TooltipManager : MonoBehaviour
{
    public static TooltipManager _instance;

    public TextMeshProUGUI textComponent;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    void Start()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.position = Mouse.current.position.ReadValue();
    }

    public void SetAndShowTooltip(string tooltip)
    {
        gameObject.SetActive(true);
        textComponent.text = tooltip;
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);
        // textComponent.text = string.Empty;
    }
}
