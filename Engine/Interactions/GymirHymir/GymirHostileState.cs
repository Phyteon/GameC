using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class GymirHostileState : GymirState
    {
        public override void RunContent(GameSession parentSession, GymirEncounter myself, HymirEncounter myBrother)
        {
            parentSession.SendText("\nYou again, thief? Just wait until my back pain gets better... ");
            return;
        }
    }
}
