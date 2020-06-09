using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MageQuest
{
    [Serializable]

    class PhoenixNest:ConsoleInteraction
    {
        private HelpfulMage myMage;

        public PhoenixNest(GameSession ses, HelpfulMage myMage) : base(ses)
        {
            Name = "interaction1124";
            Enterable = true;
            this.myMage = myMage;
        }
        protected override void RunContent()
        {
            if (myMage.NumberOfPhoenixFeather >= 2)
            {
                parentSession.SendText("Cave is clear");
                return;
            }

            parentSession.FightThisMonster(new Phoenix(1));

            if (myMage.PartOfHelpfulMageQuest == 2)
            {
                if (Index.RNG(1, 101) < 50)
                {
                    myMage.NumberOfPhoenixFeather += 1;
                    parentSession.SendText("Congratulations, you get Fhoenix Feather, you have: " + myMage.NumberOfPhoenixFeather + " Phoenix Feather");
                }
                else
                {
                    parentSession.SendText("Sorry, nothing dropped, try one more time");
                }
            }

        }
    }
}