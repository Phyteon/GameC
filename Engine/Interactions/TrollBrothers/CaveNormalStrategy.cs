using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TrollBrothers
{
    [Serializable]
    class CaveNormalStrategy : ICave
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            parentSession.FightRandomMonster();
            parentSession.FightRandomMonster();
            parentSession.FightRandomMonster();
        }
    }
}
