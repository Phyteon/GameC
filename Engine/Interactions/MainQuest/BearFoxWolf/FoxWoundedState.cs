﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Fox
{
    [Serializable]
    class FoxWoundedState : FoxState
    {
        public override void RunContent(GameSession parentSession, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
        {
            parentSession.SendText("This fox is wounded. You can save him to gain new companion or kill it get new armor.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Kill anmial (new hat)", "Hill for 20 gold (new companion)" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("\n You gain Fox Hat");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0130"));// fox hat item
                    parentSession.RemoveCurrentlyVisitedInteraction();
                    break;
                case 1:
                    parentSession.SendText("\n You gain new companion.");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0121")); // fox companion
                    parentSession.UpdateStat(8, -20);
                    parentSession.RemoveCurrentlyVisitedInteraction();
                    break;
            }
        }
    }
}
