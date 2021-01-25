using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Fox
{
    [Serializable]
    class FoxEncounter : PlayerInteraction
        {
        public List<BasicWitch.BasicWitchEncounter> bWitches;
        public MainWitch.MainWitchEncounter mWitch;
        public FoxState currentState;
            public FoxEncounter(GameSession ses, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch) : base(ses)
            {
                parentSession = ses;
                Name = "interaction0022";
                currentState = new FoxWaitState();
                this.bWitches = bWitches;
                this.mWitch = mWitch;
                Enterable = false;
            }
            protected override void RunContent()
            {
                currentState.RunContent(parentSession, bWitches, mWitch);
            }
            public void ChangeState(FoxState newState)
            {
                currentState = newState;
            }
        }
    }

