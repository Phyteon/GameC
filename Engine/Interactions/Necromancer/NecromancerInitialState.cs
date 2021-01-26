using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    class NecromancerInitialState : NecromancerState
    {
        
        public override void RunContent(GameSession parentSession, NecromancerEncounter necro, LichEncounter lich)
        {
            parentSession.SendText("\n");
            // get player choice
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Fine, i will do it","Why would i trust you","I think, I will kill you instead" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("You will need this");
                    parentSession.AddThisItem(necro.Key);
                    necro.QuestStarted = true;
                    necro.ChangeState(new NecromancerQuestStartState());
                    break;
                case 1:
                    parentSession.SendText("It doesen't matter if we trust each other, what matter is that we both need some help");
                    int choice2 = parentSession.GetListBoxChoice(new List<string>() { "Fine, but don't try anything","Or i can just kill you" });
                    if (choice2 == 0)
                    {
                        parentSession.SendText("You will need this");
                        parentSession.AddThisItem(necro.Key);
                        necro.QuestStarted = true;
                        necro.ChangeState(new NecromancerQuestStartState());
                        break;

                    }
                    if (choice2 == 1)
                    {
                        parentSession.SendColorText("I don't have time for this!", "red");
                        parentSession.SendText("It looks like he teleported you outside the tower");
                        necro.ChangeState(new NecromancerHostileState());
                        break;
                    }
                    else parentSession.SendText("");
                    break;
                default:
                    parentSession.SendColorText("I don't have time for this!","red");
                    parentSession.SendText("It looks like he teleported you outside the tower");
                    necro.ChangeState(new NecromancerHostileState());
                    break;
            }
        }

        
        
    }
}
