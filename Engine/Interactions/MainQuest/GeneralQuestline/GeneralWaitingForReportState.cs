using Game.Engine.Interactions.GeneralQuestline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class GeneralWaitingForReportState : GeneralState
    {
        public override void RunContent(GameSession parentSession, GeneralEncounter myself, TrainingEncounter training, CampEncounter camp, LibrarianEncounter librarian, TreantEncounter treant)
        {
            parentSession.SendText("\nOh, it's you. Got anything for me?");
            if (camp.Complete && camp.Decision)
            {
                parentSession.GetListBoxChoice(new List<string>() { "*Tell everything you saw at the camp*" });
                parentSession.SendText("\nHmm, that seems quite unusual. Even though the camp is close to the forest, if it was a big creature i would expect the soldiers to spot it. We surely should find out what killed them");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nI want you to examine the area near the camp, especially close to the forest. Make sure it's free of any danger. Meanwhile i will send some other soldiers back to that camp. I am planning to explore some areas of this forest soon, so this area can't be left unguarded.");
                parentSession.GetListBoxChoice(new List<string>() { "Yes, Sir" });
                parentSession.SendText("\nOone more thing. Just in case, you should probably see the librarian named Marvin. If enyone knows anything about creatures living in that forest it's probably him.");
                parentSession.GetListBoxChoice(new List<string>() { "I'll be on my way then" });
                librarian.ChangeState(new LibrarianForestInfoState());
                myself.ChangeState(new GeneralDuringTreantState());
                camp.ChangeState(new CampCompleteTruthState());
            }
            else if (camp.Complete && !camp.Decision)
            {
                parentSession.GetListBoxChoice(new List<string>() { "*Lie to the general that the camp was attacked by bandits*" });
                parentSession.SendText("\nDamn it! I knew these bastards were hiding in the forest. I am planning to explore some areas of this forest soon, and it's not acceptable that anything will bother my soldiers");
                parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                parentSession.SendText("\nI want you to examine areas of the forest close to the camp, and make sure there are no bandit hideouts there. If they are wise enough, they already ran away, but we need to be sure.");
                parentSession.GetListBoxChoice(new List<string>() { "Yes, Sir" });
                myself.ChangeState(new GeneralDuringTreantState());
                camp.ChangeState(new CampCompleteLieState());
                treant.Strategy = new TreantActiveStrategy();
            }
            else
            {
                parentSession.GetListBoxChoice(new List<string>() { "No, not yet" });
                parentSession.SendText("\nWhat are you still doing here? Go to the camp and get the report!");
                parentSession.GetListBoxChoice(new List<string>() { "Yes, Sir. I'm on my way" });
                parentSession.SendText("");
                return;
            }
        }
    }
}