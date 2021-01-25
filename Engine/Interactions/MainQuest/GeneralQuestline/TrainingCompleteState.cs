using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class TrainingCompleteState : TrainingState
    {
        public override void RunContent(GameSession parentSession, TrainingEncounter myself)
        {
            parentSession.SendText("\nIt's you again. You have completed your training already. I have other recruits to teach.");
            return;
        }
    }
}