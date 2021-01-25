using Game.Engine.Interactions.GeneralQuestline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class GeneralTrainingCompletionState : GeneralState
    {
        public override void RunContent(GameSession parentSession, GeneralEncounter myself, TrainingEncounter training, CampEncounter camp, LibrarianEncounter librarian, TreantEncounter treant)
        {
            if(training.Complete)
            {
                parentSession.SendText("\nAll right, you are officialy ready to take orders now. Actually i need you to do something for me right away.");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nThere is a small soldier camp on the border between the ... forest. They are to inform me about current status in that area, either when it's safe or when there are any dangers."); // update forest name later
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nI was supposed to recieve a raport from them yesterday, however i did not hear from them. It's most likely nothing serious, might be just a slight delay.");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nI need you to go and check on them");
                parentSession.GetListBoxChoice(new List<string>() { "Yes, Sir" });
                myself.ChangeState(new GeneralWaitingForReportState());
                camp.ChangeState(new CampDeadState());
            }
            else
            {
                parentSession.SendText("\nHave you completed your basic training yet?");
                parentSession.GetListBoxChoice(new List<string>() { "No, I will get right on it" });
                return;
            }
            
        }
    }
}