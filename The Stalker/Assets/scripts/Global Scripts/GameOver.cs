using UnityEngine;


public class GameOver: MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;


    public void ActivateGameOver ()
    {
        _gameOver.SetActive(true);
    }

}
