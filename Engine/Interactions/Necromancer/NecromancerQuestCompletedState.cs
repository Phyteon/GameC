using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    class NecromancerQuestCompletedState : NecromancerState
    {
        public override void RunContent(GameSession parentSession, NecromancerEncounter necro, LichEncounter lich)
        {
            parentSession.SendText("The gate of the tower is closed by a powerful magic, you won't be able to enter it anymore");
        }
    }
}
