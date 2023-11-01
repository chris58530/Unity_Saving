using System;
using UnityEngine;

namespace _.Scripts.Player
{
    public class PlayerWeapon : MonoBehaviour
    {
        [SerializeField] private int attackValue;

      

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IDamageable>(out var damageObj)) return;
            damageObj.OnTakeDamage(attackValue);
        }
    }
}