﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Wolf
{
    [Serializable]
    class WolfTrappedState : WolfState
    {
        public override void RunContent(GameSession parentSession, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
        {
            parentSession.SendText("This wolf is imprisoned. You save him, but this will change witches attribute.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Leave animal", "Save animal" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("\n*Wolf is looking at you with his sad eyes*");
                    
                    break;
                case 1:
                    parentSession.SendText("\n You gain new companion.");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0123")); // wolf companion
                    parentSession.SendText("\n Witches are angry now.");
                    foreach (BasicWitch.BasicWitchEncounter bWitch in bWitches)
                    {
                        bWitch.Strategy = new BasicWitch.BasicWitchHostileStrategy();
                    }
                    mWitch.ChangeState(new MainWitch.MainWitchAnimalState());
                    // zmienia nastawienie wiedźm na mapie
                    parentSession.RemoveCurrentlyVisitedInteraction();
                    break;
            }
        }
    }
}
