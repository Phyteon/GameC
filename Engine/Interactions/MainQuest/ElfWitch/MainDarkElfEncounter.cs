using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainDarkElf
{
    [Serializable]
    class MainDarkElfEncounter : PlayerInteraction
    {
        public MainDarkElfState currentState;
        public MainWitch.MainWitchEncounter mWitch;
        //public BasicDarkElf.BasicDarkElfEncounter bElf;
        List<BasicDarkElf.BasicDarkElfEncounter> bElfs;
        public MainDarkElfEncounter(GameSession ses, MainWitch.MainWitchEncounter mWitch, List<BasicDarkElf.BasicDarkElfEncounter> bElfs) : base(ses)
        {
            parentSession = ses;
            Name = "interaction00026";
            currentState = new MainDarkElfFirstState();
            this.mWitch = mWitch;
            this.bElfs = bElfs;
            Enterable = false;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, mWitch, bElfs);
        }
        public void ChangeState(MainDarkElfState newState)
        {
            currentState = newState;
        }
    }
}
