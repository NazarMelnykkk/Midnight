using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    public int MaxHealth = 100;
    [SerializeField] private int _currentHealth = 100;

    public Action<int> OnHealthChangeEvent;
    public Action OnDieEvent;

    public void ApplyDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Die();
            }

            HealthUpdated();
        }
    }

    private void HealthUpdated()
    {
        OnHealthChangeEvent?.Invoke(_currentHealth);
    }

    private void Die()
    {
        OnDieEvent?.Invoke();
    }
}
