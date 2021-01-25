using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    abstract class CampState
    {
        public abstract void RunContent(GameSession ses, CampEncounter myself);
    }
}