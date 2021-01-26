using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    abstract class NecromancerState
    {   
        public abstract void RunContent(GameSession ses, NecromancerEncounter necro, LichEncounter lich);
    }
}

