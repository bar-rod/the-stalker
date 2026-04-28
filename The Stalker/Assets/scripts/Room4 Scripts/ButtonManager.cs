using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void EnablePopup(GameObject popupParent)
    {
        popupParent.SetActive(true);
    }
}
