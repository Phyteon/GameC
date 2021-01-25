using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainDarkElf
{
    [Serializable]
    class MainDarkElfGratefulState : MainDarkElfState
    {
        public override void RunContent(GameSession parentSession, MainDarkElfEncounter myself, MainWitch.MainWitchEncounter mWitch, List<BasicDarkElf.BasicDarkElfEncounter> bElfs)
        {
            parentSession.SendText("\nGood luck.");
        }
    }
}
