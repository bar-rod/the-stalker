using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Room1ExitDoor : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private CanvasGroup fadeCanvasGroup;
    [SerializeField] private float fadeDuration = 1.0f;

    private bool isTransitioning = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(TransitionToScene());
    }

    private IEnumerator TransitionToScene()
    {
        isTransitioning = true;

        float t = 0;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
