using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    // hostile Hymir strategy - you will fight Hymir's pet (which is a randomly generated monster)

    [Serializable]
    class HymirHostileStrategy : IHymirStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("\nHello adventurer. Wait, you must be the person who robbed my older brother Gymir! You will regret that.");
            parentSession.SendText("Quickly Charlie, get him!");
            parentSession.FightRandomMonster();
            return true; // executing this strategy means HymirEncounter is now complete
        }
    }
}
