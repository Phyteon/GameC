using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class OldTravelerComplete : OldTravelerState
    {
        public override void RunContent(GameSession parentSession, OldTravelerEncounter myself)
        {
            parentSession.SendText("\nHello again. You have done everything I wanted, so I don't have any work for you. Goodbye!");
            return;
        }
    }
}
