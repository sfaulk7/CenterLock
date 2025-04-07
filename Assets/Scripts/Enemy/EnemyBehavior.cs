using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private float _acceleration = 1.0f;

    [SerializeField]
    private float _maxSpeed = 5.0f;


    public Rigidbody Player;

    private Rigidbody _enemy;

    // Start is called before the first frame update
    void Start()
    {
        _enemy = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _enemy.transform.LookAt(Player.transform.position);
        _enemy.AddForce(_enemy.transform.forward * _speed);

        Vector3 newVelocity = _enemy.velocity;
        newVelocity.x = Mathf.Clamp(newVelocity.x, -_maxSpeed, _maxSpeed);
        _enemy.velocity = newVelocity;
    }
}
