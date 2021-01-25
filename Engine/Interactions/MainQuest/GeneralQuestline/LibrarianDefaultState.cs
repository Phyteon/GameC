using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class LibrarianDefaultState : LibrarianState
    {
        public override void RunContent(GameSession parentSession, LibrarianEncounter myself, TreantEncounter treant)
        {
            parentSession.SendText("\n*The Librarian is so pensive, that he doesn't even notice you* ");
            return;
        }
    }
}
