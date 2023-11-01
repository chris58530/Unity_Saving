using System;
using System.Collections.Generic;
using UnityEngine;

namespace _.Scripts.Player
{
    public class AttackDetect : MonoBehaviour
    {
        private readonly List<GameObject> _damageObj = new List<GameObject>();


        public Vector3 GetAttackTarget()
        {
            if (_damageObj.Count <= 0) return transform.forward;

            float closestDistance = 100;
            Vector3 targetPos = Vector3.zero;
            foreach (var target in _damageObj)
            {
                float distance = Vector3.Distance(target.transform.position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    targetPos = target.transform.position;
                }
            }

            return targetPos;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent<IDamageable>(out var damageable)) return;

            if (!_damageObj.Contains(other.gameObject))
            {
                _damageObj.Add(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent<IDamageable>(out var damageable)) return;
            _damageObj.Remove(other.gameObject);
        }
    }
}