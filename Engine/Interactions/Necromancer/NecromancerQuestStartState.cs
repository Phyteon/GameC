using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    class NecromancerQuestStartState : NecromancerState
    {
        public override void RunContent(GameSession parentSession, NecromancerEncounter necro, LichEncounter lich)
        {
            int choice = parentSession.GetListBoxChoice(new List<string>() { "*Leave*", "I think, I will kill you instead" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("And finish your job fast, i dont have time for this");
                    break;

                default:
                    parentSession.SendColorText("I don't have time for this!", "red");
                    parentSession.SendText("It looks like he teleported you outside the tower");
                    necro.ChangeState(new NecromancerHostileState());
                    break;
            }
        }
    }
}

