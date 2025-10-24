using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetButton: MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name );
    }
}
