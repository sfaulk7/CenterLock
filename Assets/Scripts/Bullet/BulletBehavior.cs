using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [SerializeField]
    private float _bulletSpeed = 500.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Sets the bullets velocity
        //_bullet.velocity = ((_bullet.velocity) * _bullet.transform.up.magnitude) * _bulletSpeed;
        //_bullet.velocity = (new Vector3(100, 100, 100));
        //_bullet.AddForce(new Vector3(100, 100, 100));


        //Vector3 deltaMovement = new Vector3();
        //deltaMovement.x = 1 * 10000;
        //AddForce(deltaMovement * 10000 * Time.deltaTime, ForceMode.Impulse);

        //Vector3 newVelocity = _bullet.velocity;
        //newVelocity.x = Mathf.Clamp(newVelocity.x, -10000, 10000);
        //_bullet.velocity = newVelocity;

        float j = 0.01f;
        transform.Translate(transform.up * j);
    }
}
