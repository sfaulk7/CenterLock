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
    private GameObject _enemySpawner;

    [SerializeField]
    private Image _winTextBackground;

    [SerializeField]
    private Image _loseTextBackground;

    public UnityEvent OnGameWin;
    public UnityEvent OnGameLose;
    public UnityEvent OnGamePause;
    public UnityEvent OnGameResume;

    private PlayerRotateToMouse _playerRotate;
    private PlayerShootBullet _playerBullet;
    private PlayerShootLazer _playerLazer;
    private PointSystem _pointSystem;
    private HealthSystem _healthSystem;
    private EnemyBehavior _enemyBehavior;
    private Rigidbody _playerRigidbody;
    private Rigidbody _enemyRigidbody;

    private bool _gameWon = false;
    private bool _gameLost = false;

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
            if (!(_player.TryGetComponent<PointSystem>(out _pointSystem)))
                Debug.LogError("GameManager: Start, Could not get _pointSystem");
            if (!(_player.TryGetComponent<HealthSystem>(out _healthSystem)))
                Debug.LogError("GameManager: Start, Could not get _healthSystem");
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnGamePause.Invoke();
            StopGame();
        }

        //If game has already been won or lost do nothing
        if (_gameWon || _gameLost)
        {
            return;
        }
        if (_player.GetComponent<PointSystem>().CurrentScore >= 15)
        {
            _gameWon = true;
            Win("You Win!");
            return;
        }
        if (_player.GetComponent<HealthSystem>().CurrentHealth <= 0)
        {
            _gameLost = true;
            Lose("You Lost!");
            return;
        }
    }

    private void StopGame()
    {
        if (_playerRotate)
            _playerRotate.enabled = false;
        if (_playerBullet)
            _playerBullet.enabled = false;
        if (_playerLazer)
            _playerLazer.enabled = false;
        if (_playerRigidbody)
            _playerRigidbody.isKinematic = true;

        if (_enemySpawner.GetComponent<EnemySpawner>().EnemiesSpawning)
            _enemySpawner.GetComponent<EnemySpawner>().EnemiesSpawning = false;
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
        StopGame();

        OnGameWin.Invoke();
    }

    private void Lose(string winText)
    {
        //Enable win Screen UI and set the text to be winText
        if (_loseTextBackground)
        {
            _loseTextBackground.gameObject.SetActive(true);
            TextMeshProUGUI text = _loseTextBackground.GetComponentInChildren<TextMeshProUGUI>(true);

            if (text)
            {
                text.text = winText;
            }
        }
        StopGame();

        OnGameLose.Invoke();
    }

    public void ResumeGame()
    {
        if (_playerRotate)
            _playerRotate.enabled = true;
        if (_playerBullet)
            _playerBullet.enabled = true;
        if (_playerLazer)
            _playerLazer.enabled = true;
        if (_playerRigidbody)
            _playerRigidbody.isKinematic = false;

        if (!_enemySpawner.GetComponent<EnemySpawner>().EnemiesSpawning)
            _enemySpawner.GetComponent<EnemySpawner>().EnemiesSpawning = true;

        OnGameResume.Invoke();
        Debug.Log("Invoked Resume");
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