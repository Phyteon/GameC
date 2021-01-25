using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Bear
{
    [Serializable]
    class BearEncounter : PlayerInteraction
    {
        public List<BasicWitch.BasicWitchEncounter> bWitches;
        public MainWitch.MainWitchEncounter mWitch;
        public BearState currentState;  
        public BearEncounter(GameSession ses, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0020";
            currentState = new BearWaitState();
            this.mWitch = mWitch;
            this.bWitches = bWitches;
            Enterable = false;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, bWitches, mWitch);
        }
        public void ChangeState(BearState newState)
        {
            currentState = newState;
        }
    }
}

