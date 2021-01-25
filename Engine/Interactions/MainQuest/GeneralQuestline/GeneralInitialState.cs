using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class GeneralInitialState : GeneralState
    {

        public override void RunContent(GameSession parentSession, GeneralEncounter myself, TrainingEncounter training, CampEncounter camp, LibrarianEncounter librarian, TreantEncounter treant)
        {
            parentSession.SendText("\nAhh, so you are the new recruit. I'm general Terneus, you will serve under my command. Why do you even want to join the army?");
            parentSession.GetListBoxChoice(new List<string>() { "I am seeking breathtaking adventures.","I want to gain fame and glory!", "Only reason is that sweet soldier salary", "I want to become stronger", "Ehh, i don't really know..." });
            parentSession.SendText("\nWell, i don't really care, as long as you will be a good soldier. I see you have your own weapon, so you probably know how to handle a fight.");
            parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
            parentSession.SendText("\nNonetheless, every recruit has to complete basic combat training first. There is a small training camp just outside the city. Whenever you are done with this procedure come back to me - i might have some more interesting tasks for you.");
            parentSession.GetListBoxChoice(new List<string>() { "Yes, Sir" });
            //open portal
            myself.ChangeState(new GeneralTrainingCompletionState());
            return;
        }

    }
}
