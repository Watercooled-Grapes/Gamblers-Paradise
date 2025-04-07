using UnityEngine;
using System.Collections.Generic;
using Entity.Weapons;
using FishNet.Object;
using FishNet.Object.Synchronizing;

namespace Entity.Player
{
    public class PlayerWeapon : NetworkBehaviour
    {
        [SerializeField] private List<APlayerWeapon> weapons = new List<APlayerWeapon>();
        [SerializeField] private APlayerWeapon currentWeapon;

        private readonly SyncVar<int> _currentWeaponIndex = new(-1);

        private void Awake()
        {
            _currentWeaponIndex.OnChange += OnCurrentWeaponIndexChanged;
        }

        public override void OnStartClient()
        {
            base.OnStartClient();
            if (!base.IsOwner)
            {
                enabled = false;
                return;
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                FireWeapon();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
                InitializeWeapon(0);
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
                InitializeWeapon(1);
            
            if (Input.GetKeyDown(KeyCode.Alpha3))
                InitializeWeapon(2);
        }

        private void FireWeapon()
        {
            currentWeapon.Fire();
        }

        public void InitCamera(Transform playerCameraTransform)
        {
            throw new System.NotImplementedException();
        }

        public void InitializeWeapons(Transform parentOfWeapons)
        {
            for(int i = 0; i < weapons.Count; i++)
            {
                weapons[i].transform.SetParent(parentOfWeapons);
            }
            
            InitializeWeapon(0);
        }
        
        private void OnCurrentWeaponIndexChanged(int oldIndex, int newIndex, bool asServer)
        {
            for(int i = 0; i < weapons.Count; i++)
                weapons[i].gameObject.SetActive(false);
            if (weapons.Count > newIndex)
            {
                currentWeapon = weapons[newIndex];
                currentWeapon.gameObject.SetActive(true);
            }
        }
        private void InitializeWeapon(int weaponIndex)
        {
            SetWeaponIndex(weaponIndex);
        }
        
        [ServerRpc] private void SetWeaponIndex(int weaponIndex) => _currentWeaponIndex.Value = weaponIndex;

    }
}

