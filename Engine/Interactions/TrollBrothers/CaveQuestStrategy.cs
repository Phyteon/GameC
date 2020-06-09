using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.TrollBrothers
{
    [Serializable]
    class CaveQuestStrategy : ICave
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.FightRandomMonster();
                parentSession.FightRandomMonster();
                parentSession.FightRandomMonster();
            }
            else
            {
                parentSession.FightThisMonster(new AirBat(9));
                parentSession.FightThisMonster(new FireBat(9));
                parentSession.FightThisMonster(new EarthBat(9));
                parentSession.AddThisItem(new EarthStone());
                parentSession.UpdateStat(7, 100);
            }
        }
    }
}
