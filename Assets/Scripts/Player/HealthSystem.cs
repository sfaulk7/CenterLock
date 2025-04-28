using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    private float _startingHealth = 3.0f;

    [SerializeField]
    private TextMeshProUGUI _healthText;

    private float _health;

    public float CurrentHealth { get { return _health; } }

    private void Start()
    {
        _health = _startingHealth;

        if (_healthText)
        {
            _healthText.text = _health.ToString("0");
        }
    }

    public void DecreaseHealth()
    {
        _health -= 1;
    }

    private void Update()
    {
        if (_healthText)
        {
            _healthText.text = _health.ToString("0");
        }
    }
}
