using System;
using _.Scripts.Event;
using _.Scripts.UI;
using UnityEngine;

namespace _.Scripts.Player
{
    public class PlayerHurt : MonoBehaviour,IDamageable
    {
        private void OnEnable()
        {
            PlayerActions.onPlayerDead += OnDied;
        }
        private void OnDisable()
        {
            PlayerActions.onPlayerDead -= OnDied;
        }

        public void OnTakeDamage(int value)
        {
            ContextPresenter.Instance.GetHurt(value);
        }

        public void OnDied()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
