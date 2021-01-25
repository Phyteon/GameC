using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Trap
{
    [Serializable]
    class TrapBasicState : TrapState
    {
        public override void RunContent(GameSession parentSession, TrapEncounter trap)
        {
            int chance = Index.RNG(0, 10);
            if (chance < 5)
            {
                parentSession.FightThisMonster(new Monsters.Forest.Trap(), false);
                parentSession.RemoveCurrentlyVisitedInteraction();
            }
            else
            {
                parentSession.SendText("Lucky you!");
            }
        }
    }
}
