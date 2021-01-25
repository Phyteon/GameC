using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainWitch
{
    [Serializable]
    abstract class MainWitchState
    {
        public abstract void RunContent(GameSession ses, MainWitchEncounter myself, MainDarkElf.MainDarkElfEncounter mElf, List<BasicWitch.BasicWitchEncounter> bWitches);

    }
}
