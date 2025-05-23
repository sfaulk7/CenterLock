using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private PointSystem _pointSystem;
    private HealthSystem _healthSystem;

    private bool _destroyed;
    public bool Destroyed { get { return _destroyed; } }

    public Rigidbody Player;

    // Start is called before the first frame update
    void Start()
    {
        _pointSystem = Player.GetComponent<PointSystem>();
        _healthSystem = Player.GetComponent<HealthSystem>();
        _destroyed = false;
    }

    void DestroyEnemy()
    {
        if (_destroyed == false)
        {
            _destroyed = true;
            _pointSystem.IncreasePoints();
            Destroy(this.gameObject);

            return;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //If collision is with another enemy ignore
        if (collision.gameObject.TryGetComponent(out EnemyBehavior EnemyBehavior))
        {
            return;
        }

        //If collision is with the player
        if (collision.gameObject.TryGetComponent(out PlayerRotateToMouse PlayerRotateToMouse))
        {
            _healthSystem.DecreaseHealth();
            Destroy(this.gameObject);
            return;
        }

        //If collision is with anything else
        else
        {
            //Destroy enemy
            DestroyEnemy();

            //Destroy collided with object if it is a bullet
            if (collision.gameObject.TryGetComponent(out BulletBehavior BulletBehavior))
            {
                Destroy(collision.gameObject);
            }

            return;
        }
    }

    private void Update()
    {

    }
}
