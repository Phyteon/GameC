using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Amulet
{
    [Serializable]
    abstract class AmuletState
    {
        public abstract void RunContent(GameSession ses);
    }
}
