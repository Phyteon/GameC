using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    class NecromancerDeadState : NecromancerState
    {
        public override void RunContent(GameSession parentSession, NecromancerEncounter necro, LichEncounter lich)
        {
            parentSession.SendText("The tower stays empty, he could ressurect others, but not himself... ironic");
        }
    }
}
