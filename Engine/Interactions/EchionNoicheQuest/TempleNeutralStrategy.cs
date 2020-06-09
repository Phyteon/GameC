using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class TempleNeutralStrategy : ITempleStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\n*You definitly won't go inside it again unless you have a good reason*");
                return;
            }
            else
            {
                parentSession.SendText("\n*You entered a weird looking temple. You feel very uncomfortable. There is a piedestal in the middle.*");
                parentSession.SendText("\n*Piedestal is empty. It looks like there was some sort of medallion laying here before. This place looks like... a prison*");
                parentSession.SendText("\n*You have a feeling that someone is here. And wants to get out. You do not want to be here when that happens*");
                parentSession.SendText("\n*You are running away from the temple as quickly as possible*");
                parentSession.UpdateStat(7, 20);
            }
        }
    }
}
