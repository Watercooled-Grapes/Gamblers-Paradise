using FishNet.Object;
using UnityEngine;

namespace Entity
{
    public class EntityHealthManager : NetworkBehaviour
    {
        [SerializeField] private int maxHealth = 100;

        private int _currentHealth;

        public override void OnStartClient()
        {
            base.OnStartClient();

            if (!IsOwner)
            {
                enabled = false;
                return;
            }
            _currentHealth = maxHealth;
        }
        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;
            Debug.Log("Player Health: " + _currentHealth);
            if (_currentHealth <= 0)
            {
                Die();
            }
        }
        private void Die()
        {
            Debug.Log("Played died");
        }
    }
}
