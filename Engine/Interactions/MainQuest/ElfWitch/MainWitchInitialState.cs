using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainWitch
{
    [Serializable]
    class MainWitchInitialState : MainWitchState
    {
        public override void RunContent(GameSession parentSession, MainWitchEncounter myself, MainDarkElf.MainDarkElfEncounter mElf, List<BasicWitch.BasicWitchEncounter> bWitches)
        {
            parentSession.SendText("\nWhat are you doing here... INTRUDER!?");
            // get player choice
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Shh... Dont'w worry. I don't wanna fight. Could you tell me who this temple belongs to?  ", "I'm here for answers. Tell me who this temple was built for or die!" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("\nOf course, but everything has it's price. Go to the dark elves camp and bring me a head of their leader.");
                    myself.ChangeState(new MianWitchWaitingState());
                    mElf.ChangeState(new MainDarkElf.MainDarkElfTaregtState());
                    myself.ChangeState(new MianWitchWaitingState());
                    break;
                case 1:
                    parentSession.SendText("You will be choking with your own blood!.");
                    parentSession.FightThisMonster(new Monsters.Forest.MainWitch(), false);
                    parentSession.SendText("Ok, you won! I will tell you but spare my life. It was built by fairies to woship the spirit of the Moon. \n Leave me alone I will pay you.");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Was it so hard?. Now get out of my way.", "No, thank you." });
                    switch (choice2)
                    {
                        case 0:
                            myself.ChangeState(new MainWitchGratefulState());
                            parentSession.UpdateStat(8, 50);
                            break;
                        case 1:
                            parentSession.RemoveCurrentlyVisitedInteraction();
                            mElf.ChangeState(new MainDarkElf.MainDarkElfDeadWitchState());
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
    }
}
