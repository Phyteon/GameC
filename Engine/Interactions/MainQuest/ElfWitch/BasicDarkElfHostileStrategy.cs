using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.BasicDarkElf
{
    [Serializable]
    class BasicDarkElfHostileStrategy : IBasicDarkElfStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("\nDIE YOU MEASERABLE CREATURE.");
            parentSession.FightThisMonster(new Monsters.Forest.BasicDarkElf(), true);
            parentSession.RemoveCurrentlyVisitedInteraction();
            return false; 
        }
    }
}
