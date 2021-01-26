using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class OldTravelerHostileState : OldTravelerState
    {
        public override void RunContent(GameSession parentSession, OldTravelerEncounter myself)
        {
            parentSession.SendText("\nYou again? I told you to go away!");
            return;
        }
    }
}