using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Houndmaster
{
    abstract class HoundmasterState
    {
        public abstract void RunContent(GameSession ses, HoundmasterEncounter myself, IceHoundEncounter iceHound, FireHoundEncounter fireHound, ShadowHoundEncounter shadowHound);
    }
}
