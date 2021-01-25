using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class CampCompleteLieState : CampState
    {
        public override void RunContent(GameSession parentSession, CampEncounter myself)
        {
            parentSession.SendText("\nHello there, soldier. We've heard a roumor that previously soldiers here were robbed and killed by bandits. HAH! They must have been weak! Anyway, you probably should go, we are on the watch afterall.");
            return;
        }
    }
}
