using FishNet.Object;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerHealth : NetworkBehaviour
{
    [SerializeField] private int maxHealth = 100;

    private int _currentHealth;

    private void Awake() {
        _currentHealth = maxHealth;
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        // if (!IsOwner) { // disable for local unity testing (TODO: switch health system to an abstract class to make other things shootable)
        //     enabled = false;
        //     return;
        // }
    }

    [ServerRpc(RequireOwnership = false)]
    public void TakeDamage(int damage) {
        _currentHealth -= damage;

        Debug.Log(_currentHealth);

        if (_currentHealth <= 0) {
            Die();
        }
    }

    private void Die() {
        Destroy(gameObject); // placeholder
    }
}
