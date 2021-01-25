using Game.Engine.Interactions.GeneralQuestline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class CampTemporaryState : CampState
    {
        public override void RunContent(GameSession parentSession, CampEncounter myself)
        {
            parentSession.SendText("\n*There's nothing left for you to do here. You should head back to the general*");
            return;
        }
    }
}
