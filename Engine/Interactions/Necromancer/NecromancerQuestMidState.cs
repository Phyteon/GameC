using Game.Engine.Monsters;
using Game.Engine.Monsters.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    class NecromancerQuestMidState : NecromancerState
    {
        public override void RunContent(GameSession parentSession, NecromancerEncounter necro, LichEncounter lich)
        {
            parentSession.SendText("\n");
            switch (parentSession.GetListBoxChoice(new List<string>() { "I hope you will keep your word \n*Give the staff*", "I think, I will keep it for myself" }))
            {
                case 0:

                    parentSession.SendText("\n");
                    parentSession.RemoveThisItem(necro.Staff);
                    necro.ChangeState(new NecromancerQuestCompletedState(), true);
                    parentSession.UpdateStat(8, 1500);
                    break;

                default:
                    parentSession.SendColorText("Only for the rest of your life", "red");
                    parentSession.FightThisMonster(new HostileNecromancer());
                    necro.ChangeState(new NecromancerDeadState(), true);
                    parentSession.UpdateStat(8, 500);
                    break;

            }
        }
    }
}
