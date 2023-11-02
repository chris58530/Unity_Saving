using _.Scripts.UI;
using UnityEngine;

namespace _.Scripts.Player
{
    public class PlayerHurt : MonoBehaviour,IDamageable
    {
        public void OnTakeDamage(int value)
        {
            ContextPresenter.Instance.GetHurt(value);
        }

        public void OnDied()
        {
            
        }
    }
}
