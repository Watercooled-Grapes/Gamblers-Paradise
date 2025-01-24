using FishNet.Object;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour
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
        TakeDamage(damage);
    }

    [ServerRpc(RequireOwnership = false)]
    private void TakeDamageServer(int damage)
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
