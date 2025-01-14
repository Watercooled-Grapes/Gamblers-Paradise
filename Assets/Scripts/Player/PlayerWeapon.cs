using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    public void InitCamera(Transform parent) {
        weapon.transform.SetParent(parent);
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            weapon.Shoot();
        }
    }
}
