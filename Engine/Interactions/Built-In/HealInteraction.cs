using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // a special interaction used for healing 
    // if you want a clear example of how to write your own interesting interaction, this is probably NOT the right place 
    // see Gymir and Hymir files instead

    [Serializable]
    class HealInteraction : PlayerInteraction
    {
        public HealInteraction(GameSession parentSession) : base(parentSession)
        {
            Name = "interaction0005";
            Enterable = false;
        }

        protected override void RunContent()
        {
            int hpToHeal = parentSession.currentPlayer.LostHP;
            if(hpToHeal == 0)
            {
                parentSession.SendText("\nGreetings traveler. I'm a doctor who tends to sick and wounded, but it seems you don't need my help right now.");
                return;
            }
            parentSession.SendText("\nGreetings traveler. I'm a doctor who tends to sick and wounded. Let me see what I can do for you.");
            parentSession.SendText("Uh oh... well, I can heal you for " + hpToHeal + " HP, but it will also cost you " + 2 * hpToHeal + " gold.");
            List<string> choices = new List<string>() { "Yes, please.", "Thank you, I've changed my mind" };
            int a = parentSession.GetListBoxChoice(choices);
            if (a == 0)
            {
                if (parentSession.CheckStat(8) >= 2 * hpToHeal)
                {
                    parentSession.UpdateStat(1, hpToHeal);
                    parentSession.UpdateStat(8, -2 * hpToHeal);
                    parentSession.currentPlayer.LostHP = 0;
                    parentSession.SendText("Now you are good to go! Take care next time.");
                }
                else parentSession.SendText("Well, I'm sorry, but it seems you don't have enough money and we doctors don't work for free.");
            }
            else parentSession.SendText("That's not a smart choice, but as you wish.");
        }
    }
}
