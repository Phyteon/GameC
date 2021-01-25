using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Wolf
{
    [Serializable]
    class WolfWaitState : WolfState
    {
        public override void RunContent(GameSession parentSession, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
        {
            parentSession.SendText("\nGrrr...");
        }
    }
}
