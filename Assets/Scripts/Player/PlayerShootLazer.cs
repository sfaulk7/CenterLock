using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShootLazer : MonoBehaviour
{

    [SerializeField]
    private Object _lazerSpawnPoint;

    [SerializeField]
    private Rigidbody _lazer;

    [SerializeField]
    private float _shootCooldown = 1.0f;

    [SerializeField]
    private ParticleSystem _barrelFlash;

    private bool _shotRecently = false;

    public bool OnShootCooldown { get { return _shotRecently; } }

    public bool Shoot()
    {

        //If _shotRecently ignore
        if (_shotRecently)
        {
            return false;
        }

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        mousePosition.z = 0;
        _lazerSpawnPoint.GameObject().transform.up = mousePosition;

        //Sets lazer rotation and spawning position
        Vector3 lazerSpawnPosition = _lazerSpawnPoint.GameObject().transform.position;
        Quaternion rotation = _lazerSpawnPoint.GameObject().transform.rotation;
        _lazer.transform.up = mousePosition;

        //Spawns the lazer
        Instantiate(_lazer, lazerSpawnPosition * 15, rotation);

        //Play the barrel partical flash
        _barrelFlash.Play();

        //Set _shotRecently to false after _shootCooldown
        _shotRecently = true;
        Invoke(nameof(SetShotRecentlyFalse), _shootCooldown);

        return true;
    }

    private void SetShotRecentlyFalse()
    {
        _shotRecently = false;
    }

    private void Start()
    {

    }

    void Update()
    {
        //Left click
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
