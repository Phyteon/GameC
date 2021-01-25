using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Amulet
{
    [Serializable]
    class AmuletEncounter : PlayerInteraction
    {
        public AmuletState currentState;
        public AmuletEncounter(GameSession ses) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0029";
            currentState = new AmuletInitialState();
            Enterable = false;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession);
        }
        public void ChangeState(AmuletState newState)
        {
            currentState = newState;
        }
    }
}
