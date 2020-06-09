using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace Game.Engine.Interactions.MageQuest
{
    [Serializable]

    class SpiderCave : ConsoleInteraction
    {
        private HelpfulMage myMage;
       
        public SpiderCave(GameSession ses, HelpfulMage myMage) : base(ses)
        {
            Name = "interaction1123";
            Enterable = true;
            this.myMage = myMage;
        }
        protected override void RunContent()
        {
            if (myMage.NumberOfMagicThread >= 4)
            {
                parentSession.SendText("Cave is clear");
                return;
            }

            parentSession.FightThisMonster(new Spider(1));

            if (myMage.PartOfHelpfulMageQuest == 1)
            {
                if (Index.RNG(1, 101) < 75)
                {
                    myMage.NumberOfMagicThread += 1;
                    parentSession.SendText("Congratulations, you get Magic Thread, you have: " + myMage.NumberOfMagicThread + " Magic Thread");
                }
                else
                {
                    parentSession.SendText("Sorry, nothing dropped, try one more time");
                }
            }


        }
    }
}