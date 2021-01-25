using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.Wolf
{
    [Serializable]
    class WolfEncounter : PlayerInteraction
    {
        public List<BasicWitch.BasicWitchEncounter> bWitches;
        public MainWitch.MainWitchEncounter mWitch;
        public WolfState currentState;
        public WolfEncounter(GameSession ses, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0021";
            currentState = new WolfWaitState();
            this.bWitches = bWitches;
            this.mWitch = mWitch;
            Enterable = false;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, bWitches, mWitch);
        }
        public void ChangeState(WolfState newState)
        {
            currentState = newState;
        }
    }
}


