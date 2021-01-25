using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainWitch
{
    [Serializable]
    class MainWitchEncounter : PlayerInteraction
    {
        public MainWitchState currentState;
        public MainDarkElf.MainDarkElfEncounter mElf;
        //public BasicWitch.BasicWitchEncounter bWitch;
        public List<BasicWitch.BasicWitchEncounter> bWitches;
        public MainWitchEncounter(GameSession ses, MainDarkElf.MainDarkElfEncounter mElf, List<BasicWitch.BasicWitchEncounter> bWitches) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0024";
            currentState = new MainWitchFirstState();
            this.mElf = mElf;
            this.bWitches = bWitches;
            Enterable = false;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, mElf, bWitches);
        }
        public void ChangeState(MainWitchState newState)
        {
            currentState = newState;
        }
    }
}
