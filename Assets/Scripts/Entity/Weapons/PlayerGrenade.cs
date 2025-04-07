using UnityEngine;

namespace Entity.Weapons
{
    public class PlayerGrenade : APlayerWeapon
    {
    public override void AnimateWeapon()
        {
            Debug.Log("Grenade Throw");
        }
    }
    
}
