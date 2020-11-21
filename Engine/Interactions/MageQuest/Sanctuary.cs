using Game.Engine.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MageQuest
{
    [Serializable]

    class Sanctuary : PlayerInteraction
    {
        private HelpfulMage myMage;

        public Sanctuary(GameSession ses, HelpfulMage myMage) : base(ses)
        {
            Name = "interaction1125";
            Enterable = true;
            this.myMage = myMage;
        }
        protected override void RunContent()
        {

            if (myMage.NumberOfGolemEye >= 1)
            {
                parentSession.SendText("Cave is clear");
                return;
            }

            parentSession.FightThisMonster(new Golem(1));

            if (myMage.PartOfHelpfulMageQuest == 4)
            {
                myMage.NumberOfGolemEye += 1;
                parentSession.SendText("Congratulations, you get Golem's Eye, you have: " + myMage.NumberOfGolemEye + " Golem's Eye");
            }

        }
    }
}