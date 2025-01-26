    
using FishNet.Object;
using UnityEngine;

namespace Weapons
{
    public abstract class APlayerWeapon : NetworkBehaviour
    {
        public int damage;

        public LayerMask weaponHitLayers;
        private Transform _cameraTransform;

        public float maxRange = 20f;

        private void Awake()
        {
            _cameraTransform = Camera.main.transform;
        }

        public void Fire()
        {
            AnimateWeapon();

            if (!Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out RaycastHit hit, maxRange,
                    weaponHitLayers))
                return;
            if (hit.transform.TryGetComponent(out PlayerHealth health))
            {
                health.TakeDamage(damage);
            }
        }

        public abstract void AnimateWeapon();
    }
}


