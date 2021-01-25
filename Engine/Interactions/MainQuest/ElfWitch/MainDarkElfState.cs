using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainDarkElf
{
    [Serializable]
    abstract class MainDarkElfState 
    {
        public abstract void RunContent(GameSession ses, MainDarkElfEncounter myself, MainWitch.MainWitchEncounter mWitch, List<BasicDarkElf.BasicDarkElfEncounter> bElfs);
    }
}
