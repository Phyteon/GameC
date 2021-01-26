using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    [Serializable]
    abstract class GateState
    {
        public abstract void RunContent(GameSession sys, GateEncounter myself);
    }
}
