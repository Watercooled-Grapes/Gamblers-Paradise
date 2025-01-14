using System.Diagnostics;
using FishNet.Object;
using UnityEngine;

// abstract weapon class, inherit when implmenting any (HITSCAN BASED) weapon used by a player

public abstract class Weapon : NetworkBehaviour
{
    public int damage;

    public LayerMask projHitLayer;
    private Transform _cameraTransform;

    private void Awake() {
        _cameraTransform = transform.parent.gameObject.transform;
    }
    public void Shoot() {
        AnimateWeapon();

        if (!Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, Mathf.Infinity, projHitLayer)) {
            UnityEngine.Debug.DrawLine(_cameraTransform.position, _cameraTransform.forward, Color.red, 1000f);
            return;
        }

        if (hit.transform.TryGetComponent(out PlayerHealth health)) {
            health.TakeDamage(damage);
        }
    }

    public abstract void AnimateWeapon();
}
