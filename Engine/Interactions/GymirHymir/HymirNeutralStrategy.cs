using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    // neutral Hymir strategy - not much happens here

    [Serializable]
    class HymirNeutralStrategy : IHymirStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("\nHello adventurer. Have you seen my brother Gymir? I haven't heard from him in ages... ");
            parentSession.SendText("In any case, I'm pretty busy right now, so perhaps you can come back later.");
            return false; // executing this strategy means HymirEncounter is still not complete
        }
    }
}
