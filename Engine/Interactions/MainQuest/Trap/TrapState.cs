using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Trap
{
    [Serializable]
    abstract class TrapState
    {
        public abstract void RunContent(GameSession ses, TrapEncounter trap);

    }
}
