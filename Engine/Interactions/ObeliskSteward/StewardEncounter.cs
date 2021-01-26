using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // meet with an old troll named Gymir
    // Gymir has also a brother - Hymir

    [Serializable]
    class StewardEncounter : PlayerInteraction
    {
        private StewardState currentState;
        private GateEncounter TempleGate;
        public List<string> order;
        public StewardEncounter(GameSession ses, List<string> Colors, GateEncounter gate) : base(ses)
        {
            parentSession = ses;
            TempleGate = gate;
            Name = "interaction0032";           
            currentState = new StewardInitialState();
            order = Colors;
            Enterable = false;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, TempleGate);
        }
        public void ChangeState(StewardState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }
    }
}
