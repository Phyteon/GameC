using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.BasicWitch
{
    [Serializable]
    class BasicWitchHostileStrategy : IBasicWitchStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("\nDIE INTRUDER.");
            parentSession.FightThisMonster(new Monsters.Forest.BasicWitch(), true);
            parentSession.RemoveCurrentlyVisitedInteraction();
            return false; // executing this strategy means HymirEncounter is now complete
        }
    }
}
