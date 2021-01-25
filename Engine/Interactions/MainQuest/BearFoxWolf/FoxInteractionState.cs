using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Fox
{
    [Serializable]
    class FoxInteractionState : FoxState
        {
            public override void RunContent(GameSession parentSession, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
            {
                parentSession.SendText("\nGrrr...");
            parentSession.FightThisMonster(new Monsters.Forest.Fox(), false);
            parentSession.SendText("\n You can now bring animal alive or kill it.");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Kill anmial (new hat)", "Bring alive (new companion)" });
                switch (choice)
                {
                    case 0:
                        parentSession.SendText("\n You gain Fox Hat");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0130"));
                    parentSession.RemoveCurrentlyVisitedInteraction();
                        break;
                    case 1:
                        parentSession.SendText("\n Get back to Bulgur.");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0133"));
                    parentSession.RemoveCurrentlyVisitedInteraction();
                        break;
                }

            }
        }
}
