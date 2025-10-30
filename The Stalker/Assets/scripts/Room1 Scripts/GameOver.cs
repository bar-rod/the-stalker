using UnityEngine;


public class GameOver: MonoBehaviour
{
    [SerializeField] private GameObject _gameOverText;


    public void ActivateGameOver ()
    {
        _gameOverText.SetActive(true);
    }

}
