using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Wolf
{
    [Serializable]
    class WolfFightState : WolfState
    {
        public override void RunContent(GameSession parentSession, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
        {
            parentSession.SendText("\nGrrr...");
            parentSession.FightThisMonster(new Monsters.Forest.Wolf(), true);
            parentSession.RemoveCurrentlyVisitedInteraction();
        }
    }
}
