using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Trap
{
    [Serializable]
    class TrapEncounter : PlayerInteraction
    {
        private TrapState currentState;
        public TrapEncounter(GameSession ses) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0028";
            currentState = new TrapBasicState();
            Enterable = true;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this);
        }
        public void ChangeState(TrapState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }
    }
}
