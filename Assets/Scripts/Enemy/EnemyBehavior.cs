using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private float _acceleration = 5.0f;

    [SerializeField]
    private float _maxSpeed = 20.0f;

    [SerializeField]
    private Rigidbody _player;

    private Rigidbody _enemy;

    // Start is called before the first frame update
    void Start()
    {
        transform.up = _player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 deltaMovement = new Vector3();
        deltaMovement.x = 1 * _acceleration;
        _enemy.AddForce(deltaMovement * _acceleration * Time.fixedDeltaTime, ForceMode.VelocityChange);

        Vector3 newVelocity = _enemy.velocity;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -_maxSpeed, _maxSpeed);
        _enemy.velocity = newVelocity;
    }
}
