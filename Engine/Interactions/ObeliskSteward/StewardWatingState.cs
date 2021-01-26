using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class StewardWaitingState : StewardState
    {
        public override void RunContent(GameSession parentSession, StewardEncounter myself, GateEncounter gate)
        {
            parentSession.SendText("\nHi again, have you found your golem?");
            return;
        }
    }
}
