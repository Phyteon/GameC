using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainWitch
{
    [Serializable]
    class MainWitchAnimalState : MainWitchState
    {
        public override void RunContent(GameSession parentSession, MainWitchEncounter myself, MainDarkElf.MainDarkElfEncounter mElf, List<BasicWitch.BasicWitchEncounter> bWitches)
        {
            parentSession.SendText("\nGive us back our animal. It has to be sacrificed for our goddess!");
            parentSession.GetListBoxChoice(new List<string>() { "I won't let you do that!." });
            parentSession.SendText("\nYou will be sacrificed you little scum!");
            parentSession.FightThisMonster(new Monsters.Forest.MainWitch(), false);
            parentSession.SendText("Ok, you won! Take it. I will tell you somethig about the Tempel, but spare my life. It was built by fairies to woship the spirit of the Moon. Also take this gold.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Ok. Now get out of my way.", "Thank you, but die." });
            switch (choice)
            {
                case 0:
                    myself.ChangeState(new MainWitchGratefulState());
                    parentSession.UpdateStat(8, 50);
                    mElf.ChangeState(new MainDarkElf.MainDarkElfDeadWitchState());
                    break;
                case 1:
                    parentSession.RemoveCurrentlyVisitedInteraction();
                    foreach (BasicWitch.BasicWitchEncounter bWitch in bWitches)
                    {
                        bWitch.Strategy = new BasicWitch.BasicWitchHostileStrategy();
                    }
                    mElf.ChangeState(new MainDarkElf.MainDarkElfDeadWitchState());

                    parentSession.UpdateStat(7, 500);
                    break;
            }

        }
    }
}
