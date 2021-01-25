using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainDarkElf
{
    class MainDarkElfBetrayalState : MainDarkElfState
    {
        public override void RunContent(GameSession parentSession, MainDarkElfEncounter myself, MainWitch.MainWitchEncounter mWitch, List<BasicDarkElf.BasicDarkElfEncounter> bElfs)
        {
            parentSession.SendText("\nDid you get her head?");
            parentSession.GetListBoxChoice(new List<string>() { "I will get, but yours!." });
            parentSession.FightThisMonster(new Monsters.Forest.MainDarkElf(), false);
            parentSession.SendText("Ok, you won! I will tell you but spare my life. It was built by fairies to woship the spirit of the Moon. I will also pay you some gold.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Was it so hard?. Now get out of my way.", "Thank you, but die." });
            switch (choice)
            {
                case 0:
                    myself.ChangeState(new MainDarkElfGratefulState());
                    parentSession.UpdateStat(8, 50);
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0127"));
                    break;
                case 1:
                    parentSession.RemoveCurrentlyVisitedInteraction();
                    foreach(BasicDarkElf.BasicDarkElfEncounter bElf in bElfs)
                    {
                        bElf.Strategy = new BasicDarkElf.BasicDarkElfHostileStrategy();
                    }
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0126"));
                    parentSession.UpdateStat(7, 500);
                    break;
            }

        }
    }
}
