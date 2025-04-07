using UnityEngine;

namespace Entity.Weapons
{
    public class PlayerShotgun: APlayerWeapon
    {
    public override void AnimateWeapon()
        {
            Debug.Log("Shotgun Fire");
        }
    }
    
}
