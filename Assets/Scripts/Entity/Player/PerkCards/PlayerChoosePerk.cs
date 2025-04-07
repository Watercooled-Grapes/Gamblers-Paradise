using UnityEngine;

namespace Entity.Player.PerkCards 
{
    public class PlayerChoosePerk : MonoBehaviour
    {        
        private int rarity;
        private string[] choices;
        void Start()
        {
            //generateRandomChoice(rarity);
        }

        void Update()
        {
            
        }

        public void bringupChoiceMenu() // remember to reset PlayerCardManager.canChoosePerk to true after we are done (choice is made)
        {

        }
    }
}
