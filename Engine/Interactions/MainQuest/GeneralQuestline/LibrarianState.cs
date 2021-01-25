using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    abstract class LibrarianState
    {
        public abstract void RunContent(GameSession ses, LibrarianEncounter myself, TreantEncounter treant);
    }
}
