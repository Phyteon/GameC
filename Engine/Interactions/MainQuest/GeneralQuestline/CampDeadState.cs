using Game.Engine.Interactions.GeneralQuestline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class CampDeadState : CampState
    {
        public override void RunContent(GameSession parentSession, CampEncounter myself)
        {
            parentSession.SendText("\n*As you approach the camp you see it was devastated and all of the soldiers are dead*");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "I should look around for clues so I can report this to general", "These soldiers had some fine gear with them. I could take it and report that the camp was attacked and robbed by bandits" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("\n*While looking for clues you notice a small drawing of a Tree engraved in the dirt. It must have been made by the soldier shorlty before he died*");
                    parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                    parentSession.SendText("\n*It seems like they were ambushed. One soldier didn't even draw his weapon*");
                    parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                    parentSession.SendText("\n*There is a wird trail on the dirt. By looking at the depth of it, you suspect it was left by a giant animal. However the shape isn't very regular and you can't think of any animal that would leave even similar tract to the one you see*");
                    parentSession.GetListBoxChoice(new List<string>() { "*continue*" });
                    parentSession.SendText("\n*You also notice that the wounds neither match any weapons humans use, nor were they caused by wild animal teeth or claws*");
                    parentSession.GetListBoxChoice(new List<string>() { "I should go back to the general and tell him in detail what i saw" });
                    myself.ChooseDecision(true);
                    myself.ChangeState(new CampTemporaryState(), true);
                    break;
                case 1:
                    parentSession.AddRandomItem();
                    parentSession.AddRandomItem();
                    parentSession.UpdateStat(8, 35); // +35 gold 
                    myself.ChooseDecision(false);
                    myself.ChangeState(new CampTemporaryState(), true);
                    break;
                default:
                    break;
            }
        }
    }
}
