using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainWitch
{
    [Serializable]
    class MainWitchBetrayedState : MainWitchState
    {
        public override void RunContent(GameSession parentSession, MainWitchEncounter myself, MainDarkElf.MainDarkElfEncounter mElf, List<BasicWitch.BasicWitchEncounter> bWitches)
        {
            parentSession.SendText("\nDid you get his head?");
            parentSession.GetListBoxChoice(new List<string>() { "I will get, but yours!." });
            parentSession.FightThisMonster(new Monsters.Forest.MainWitch(), false);
            parentSession.SendText("Ok, you won! I will tell you but spare my life. It was built by fairies to woship the spirit of the Moon. I will also pay you some gold.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Was it so hard?. Now get out of my way.", "Thank you, but die." });
            switch (choice)
            {
                case 0:
                    myself.ChangeState(new MainWitchGratefulState());
                    parentSession.UpdateStat(8, 50);
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0129"));
                    break;
                case 1:
                    parentSession.RemoveCurrentlyVisitedInteraction();
                    foreach (BasicWitch.BasicWitchEncounter bWitch in bWitches)
                    {
                        bWitch.Strategy = new BasicWitch.BasicWitchHostileStrategy();
                    }        
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0128"));
                    parentSession.UpdateStat(7, 500);
                    break;
            }

        }
    }
}
