using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainWitch
{
    [Serializable]
    class MianWitchWaitingState : MainWitchState
    {
        public override void RunContent(GameSession parentSession, MainWitchEncounter myself, MainDarkElf.MainDarkElfEncounter mElf, List<BasicWitch.BasicWitchEncounter> bWitches)
        {

            if (parentSession.TestForItem("item0126") == false && parentSession.TestForItem("item0127") == false) // will check for a dark elf head 
            {
                parentSession.SendText("Come back to me with a head of this renegade.");
                int choice = parentSession.GetListBoxChoice(new List<string>() { "Give me some more time.", "I've changed my mid. Tell me or die!" });
                switch (choice) 
                {
                    case 0:
                        break;
                    case 1:
                        parentSession.SendText("You will be choking with your own blod!.");
                        parentSession.FightThisMonster(new Monsters.Forest.MainWitch(), false);
                        parentSession.SendText("Ok, you won! I will tell you but spare my life. It was built by fairies to woship the spirit of the Moon. I will also pay you some gold.");
                        int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Was it so hard?. Now get out of my way.", "Thank you, but die." });
                        switch (choice2)
                        {
                            case 0:
                                myself.ChangeState(new MainWitchGratefulState());
                                parentSession.UpdateStat(8, 50);
                                break;
                            case 1:
                                parentSession.RemoveCurrentlyVisitedInteraction();
                                foreach (BasicWitch.BasicWitchEncounter bWitch in bWitches)
                                {
                                    bWitch.Strategy = new BasicWitch.BasicWitchHostileStrategy();
                                }
                                parentSession.UpdateStat(7, 500);
                                break;
                        }

                        break;

                }


            }
            else if (parentSession.TestForItem("item0126") == true || parentSession.TestForItem("item0127") == true)
            {
                parentSession.SendText("Oh, you're back. Good job.");
                parentSession.SendText("So it is my turn. \n The temple was built by fairies to worship the spirit of the Moon. Now leave us alone.");
                myself.ChangeState(new MainWitchGratefulState());
            }
        }
    }
}
