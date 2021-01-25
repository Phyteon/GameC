using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainDarkElf
{
    [Serializable]
    class MainDarkElfWaitingState : MainDarkElfState
    {
        public override void RunContent(GameSession parentSession, MainDarkElfEncounter myself, MainWitch.MainWitchEncounter mWitch, List<BasicDarkElf.BasicDarkElfEncounter> bElfs)
        {


            if (parentSession.TestForItem("item0128") == false && parentSession.TestForItem("item0129") == false) // will check for a dark elf head 
            {
                parentSession.SendText("Come back to me with a head of this witch.");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Give me some more time.", "I've changed my mid. Tell me or die!" });
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        parentSession.SendText("You will be choking with your own blod!.");
                        parentSession.FightThisMonster(new Monsters.Forest.MainDarkElf(), false);
                        parentSession.SendText("Ok, you won! I will tell you but spare my life. Fairies main rule was to pray to the full Moon. I will also pay you some gold.");
                        int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Was it so hard?. Now get out of my way.", "Thank you, but die." });
                        switch (choice2)
                        {
                            case 0:
                                myself.ChangeState(new MainDarkElfGratefulState());
                                parentSession.UpdateStat(8, 50);
                                break;
                            case 1:
                                parentSession.RemoveCurrentlyVisitedInteraction();
                                foreach (BasicDarkElf.BasicDarkElfEncounter bElf in bElfs)
                                {
                                    bElf.Strategy = new BasicDarkElf.BasicDarkElfHostileStrategy();
                                }
                                parentSession.UpdateStat(7, 500);
                                break;
                        }

                        break;

                }


            }
            else if (parentSession.TestForItem("item0128") == true || parentSession.TestForItem("item0129") == true)
            {
                parentSession.SendText("Oh, you're back. Good job.");
                parentSession.SendText("So it is my turn. \n Fairies main rule was to pray to the full Moon. Now leave us alone.");
                myself.ChangeState(new MainDarkElfGratefulState());
            }
        }

    }
}

