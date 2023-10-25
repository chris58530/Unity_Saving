using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurt : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHp;
    private float _currentHp;

    private void Start()
    {
        _currentHp = maxHp;
    }

    public void OnTakeDamage(int value)
    {
        _currentHp -= value;
        if (_currentHp <= 0) OnDied();
    }

    public void OnDied()
    {
        Destroy(gameObject);
    }
}