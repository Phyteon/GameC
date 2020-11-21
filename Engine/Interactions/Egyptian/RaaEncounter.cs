using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EgyptianInteractions
{
    [Serializable]
    class RaaEncounter : PlayerInteraction,IGod
    {
        public string name = "Raa";
        int zm = 0;
        public void Die(GameSession parentSession)
        {
            parentSession.SendText("Raa is dead!");
            zm = 1;
        }
        /////
        public RaaEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0823";

        }

        int zm2 = 0;
        protected override void RunContent()
        {
            if (zm == 1)
                parentSession.SendText("Raa is dead. He can`t help you.");
            else
            {
                if (zm2 <= 2)
                {
                    parentSession.SendText("Hi, Im Raa! Ohhh, you look really bad! Here, I will give you more money! \n [Gold +5]");
                    parentSession.UpdateStat(8, 5);
                    zm2++;
                }
                else
                {
                    parentSession.SendText("You got too much from me, human! No more gold for you!");
                }
            }

        }
    }
}
