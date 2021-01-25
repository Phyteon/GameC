using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.BasicDarkElf
{
    [Serializable]
    class BasicDarkElfNeutralStrategy :IBasicDarkElfStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("\nMhm? ");
            return false; // executing this strategy means HymirEncounter is still not complete
        }
    }
}
