using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    [SerializeField]
    private GameObject _enemy;

    [SerializeField]
    private Image _winTextBackground;

    public UnityEvent OnGameWin;

    private PlayerRotateToMouse _playerRotate;
    private PlayerShootBullet _playerBullet;
    private PlayerShootLazer _playerLazer;
    private Rigidbody _playerRigidbody;

    private bool _gameWon = false;

    private void Start()
    {
        if (_player)
        {
            if (!(_player.TryGetComponent<PlayerRotateToMouse>(out _playerRotate)))
                Debug.LogError("GameManager: Start, Could not get _playerRotate");
            if (!(_player.TryGetComponent<PlayerShootBullet>(out _playerBullet)))
                Debug.LogError("GameManager: Start, Could not get _playerBullet");
            if (!(_player.TryGetComponent<PlayerShootLazer>(out _playerLazer)))
                Debug.LogError("GameManager: Start, Could not get _playerLazer");
            if (!(_player.TryGetComponent<Rigidbody>(out _playerRigidbody)))
                Debug.LogError("GameManager: Start, Could not get _playerRigidbody");
        }
        else
            Debug.LogError("GameManager: Start, Player not assigned");

        if (!(_winTextBackground))
            Debug.LogWarning("GameManager: Start, _winTextBackground not assigned");
    }

    private void Update()
    {
        //If game has already been won do nothing
        if (_gameWon)
        {
            return;
        }

        Win("You Win!");
    }

    private void Win(string winText)
    {
        //Enable win Screen UI and set the text to be winText
        if (_winTextBackground)
        {
            _winTextBackground.gameObject.SetActive(true);
            TextMeshProUGUI text = _winTextBackground.GetComponentInChildren<TextMeshProUGUI>(true);

            if (text)
            {
                text.text = winText;
            }
        }

        OnGameWin.Invoke();
    }

    public void ResetGame()
    {
        //Reload the active scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ToTitle()
    {
        //load the game scene (SampleScene)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}