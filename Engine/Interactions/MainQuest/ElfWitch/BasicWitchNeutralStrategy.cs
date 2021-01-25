using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.BasicWitch
{
    [Serializable]
    class BasicWitchNeutralStrategy : IBasicWitchStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("\nHuh? ");
            return false; // executing this strategy means HymirEncounter is still not complete
        }
    }
}
