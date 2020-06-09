using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EgyptianInteractions
{
    [Serializable]
    class HorusEncounter : ConsoleInteraction,IGod
    {
        public string name = "Horus";
        int zm = 0;
        public void Die(GameSession parentSession)
        {
            parentSession.SendText("Horus is dead. He can`t help you.");
            zm = 1;
        }
        /////
        public HorusEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0824";

        }

        int zm2 = 0;
        protected override void RunContent()
        {
            if (zm == 1)
                parentSession.SendText("Horus is dead no coins!");
            else
            {

                if (zm2 <= 2)
                {
                    parentSession.SendText("Hi, Im Horus! Ohhh, you look really tired! Here, lay down and I will give you more magic power! \n [MagicPower +5]");
                    parentSession.UpdateStat(5, 5);
                    zm2++;
                }
                else
                {
                    parentSession.SendText("You got too much from me, human! No more magic power for you!");
                }
            }
        }
    }
}
