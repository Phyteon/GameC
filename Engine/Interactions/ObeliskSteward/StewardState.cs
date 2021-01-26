using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    abstract class StewardState
    {
        public abstract void RunContent(GameSession sys, StewardEncounter myself, GateEncounter gate);
    }
}
