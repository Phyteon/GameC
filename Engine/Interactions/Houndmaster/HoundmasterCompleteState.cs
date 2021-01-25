using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Houndmaster
{
    class HoundmasterCompleteState : HoundmasterState
    {
        public override void RunContent(GameSession parentSession, HoundmasterEncounter myself, IceHoundEncounter iceHound, FireHoundEncounter fireHound, ShadowHoundEncounter shadowHound)
        {
                parentSession.SendText("\nThanks for the help once again");
        }
    }
}
