using Game.Engine.Interactions.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // meet with a troll named Hymir, who is a brother of Gymir
    // Hymir's behavior will depend on your previous interactions with Gymir, if you had them

    [Serializable]
    class GateEncounter : PlayerInteraction
    {
        private GateState CurrentState;
        public GateEncounter(GameSession ses, string name) : base(ses)
        {
            parentSession = ses;
            Name = name;
            CurrentState = new GateOpenState();    
            Enterable = true;
        }
        protected override void RunContent()
        {
            CurrentState.RunContent(parentSession, this);            
        }

        public void ChangeState(GateState newState)
        {   
            if(Enterable==false)Enterable = true;
            else if(Enterable == true)Enterable = false;
            CurrentState = newState;
        }
    }
}
