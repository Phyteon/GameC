using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Fox
{
    [Serializable]
    abstract class FoxState
    {
        public abstract void RunContent(GameSession ses, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch);
    }
}
