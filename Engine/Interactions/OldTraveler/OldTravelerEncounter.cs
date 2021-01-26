using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    [Serializable]
    class OldTravelerEncounter : PlayerInteraction
    {
        private OldTravelerState currentState;
        public OldTravelerEncounter(GameSession ses) : base(ses)
        {
            parentSession = ses;
            Name = "interaction1315";
            currentState = new OldTravelerInitialState();
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this);
        }
        public void ChangeState(OldTravelerState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true;
        }
    }
}
