using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;

namespace Entity.Player.PerkCards 
{
    public class PlayerCardManager : MonoBehaviour
    {
        private bool canChoosePerk = true;
        private int numChoosePerk = 0;
        private Stack<PlayerChoosePerk> heldChoices;
        private Dictionary<string, int> heldCards;

        void Start()
        {
            heldChoices = new Stack<PlayerChoosePerk>();
            heldCards = new Dictionary<string, int>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F)) 
            {
                consumePerkChoice();
            }
        }

        private void gainPerkChoice(PlayerChoosePerk drop) 
        {   
            heldChoices.Push(drop);
            numChoosePerk += 1;
        }

        public void setCanChoosePerk(bool tf)
        {
            canChoosePerk = tf;
        }

        private void consumePerkChoice() 
        {   
            if (canChoosePerk && numChoosePerk > 0) 
            {
                heldChoices.Pop().bringupChoiceMenu();
                numChoosePerk -= 1;
                canChoosePerk = false;
            }
        }
    }
}
