using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class GeneralAmuletState : GeneralState
    {
        public override void RunContent(GameSession parentSession, GeneralEncounter myself, TrainingEncounter training, CampEncounter camp, LibrarianEncounter librarian, TreantEncounter treant)
        {
            if (parentSession.TestForItem("item0131") == false)
            {
                parentSession.SendText("\nGo and get a Heart of the Forset soldier!");
            }
            else
            {
                parentSession.SendText("\nYou did it! Good job soldier! Now we can open a portal to [NAZWA LASU MICHAŁA]");
                // drogi Michale, tutaj możesz kontynuować swoją fabułę.
            }
        }
    }
}
