using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private float _spawnRate = 5.0f;

    [SerializeField]
    private Rigidbody _enemy;

    [SerializeField]
    private Rigidbody _player;

    private bool _spawning = false;
    public bool EnemiesSpawning { get { return _spawning; } set { _spawning = value; } }

    // Start is called before the first frame update
    void Start()
    {
        _spawning = true;
        Invoke(nameof(SpawnEnemy), _spawnRate);
    }

    void SpawnEnemy()
    {
        Rigidbody Enemy = Instantiate(_enemy, transform.position, Quaternion.identity);
        Enemy.GetComponent<EnemyBehavior>().Player = _player;
        Enemy.GetComponent<EnemyDeath>().Player = _player;

        if (_spawning)
        {
            Invoke(nameof(SpawnEnemy), _spawnRate);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
