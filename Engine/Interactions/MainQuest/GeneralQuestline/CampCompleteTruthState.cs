using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class CampCompleteTruthState : CampState
    {
        public override void RunContent(GameSession parentSession, CampEncounter myself)
        {
            parentSession.SendText("\nDon't distract us! I don't want to end up killed by some monster from woods. If you don't need to be here you should go away");
            return;
        }
    }
}
