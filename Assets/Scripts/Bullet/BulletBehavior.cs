using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    //_bulletSpeed values will be a lot higher than other speed values as it doesnt accelerate,
    //instead intantly taking off at top speed
    [SerializeField]
    private float _bulletSpeed = 500;

    private Rigidbody _bullet;

    // Start is called before the first frame update
    void Start()
    {
        _bullet = GetComponent<Rigidbody>();
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        mousePosition.z = 0;
        _bullet.transform.LookAt(mousePosition);

        _bullet.AddForce(_bullet.transform.forward * _bulletSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
