using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Health _health;
    [SerializeField] private Image _healthBar;

    private int _maxHealth;

    private void Start()
    {
        _maxHealth = _health.MaxHealth;
    }

    private void OnEnable()
    {
        _health.OnHealthChangeEvent += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _health.OnHealthChangeEvent -= UpdateHealthBar;
    }


    private void UpdateHealthBar(int value)
    {
        _healthBar.fillAmount = (float)value / _maxHealth;
    }
}
