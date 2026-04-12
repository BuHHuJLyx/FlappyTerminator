using System;
using UnityEngine;

public class Health : MonoBehaviour, IDamageable
{
    private int _maxHealth = 1;
    private int _currentHealth;

    public event Action Depleted;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Depleted?.Invoke();
    }
}