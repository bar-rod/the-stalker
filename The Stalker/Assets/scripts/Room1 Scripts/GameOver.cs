using UnityEngine;


public class GameOver: MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] private GameObject _gameOverText;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ActivateGameOver();
        }
    }

    private void ActivateGameOver ()
    {
        if (timer <= 0)
        {
            _gameOverText.SetActive(true);
        }
    }

}
