using System;
using System.Collections.Generic;
using UnityEngine;

namespace _.Scripts.Player
{
    public class PullDetect : MonoBehaviour
    {
        private readonly List<IPullable> _pullableObject = new List<IPullable>();

        public List<IPullable> PullableObjects => _pullableObject;

        public void SetDetectRange(float range)
        {
            transform.localScale = new Vector3(range, 1, range);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent<IPullable>(out var pullable)) return;

            if (!_pullableObject.Contains(pullable))
            {
                _pullableObject.Add(pullable);
                Debug.Log($"{other.gameObject.name}");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent<IPullable>(out var pullable)) return;
            _pullableObject.Remove(pullable);
        }
    }
}