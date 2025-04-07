using UnityEngine;

namespace Entity.Weapons
{
    public class PlayerRifle : APlayerWeapon
    {
        
        
        public override void AnimateWeapon()
        {
            Debug.Log("Rifle Fire");
        }
    }
    
}
