using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Houndmaster
{
    class HoundmasterWaitingState : HoundmasterState
    {
        public override void RunContent(GameSession parentSession, HoundmasterEncounter myself, IceHoundEncounter iceHound, FireHoundEncounter fireHound, ShadowHoundEncounter shadowHound)
        {
            if(iceHound.Complete && fireHound.Complete && shadowHound.Complete)
            {
                parentSession.SendText("\nOh, i see you managed to find all of them. That's really great. Here's your reward for the help");
                parentSession.UpdateStat(8, 225);
                myself.ChangeState(new HoundmasterCompleteState(), true);
                
            }
            else
            {
                parentSession.SendText("\nCome back when you manage to find all of the hounds");
                return;
            }

        }
    }
}
