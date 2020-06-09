using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class NoicheNeutralStrategy : INoicheStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            parentSession.SendText("\nHello adventurer. Could you help me find my medalion? Ice troll stole it from me.");
            parentSession.SendText("\nNo matter if you want to help me or not, I shall be waiting here with payment so don't worry!");
        }
    }
}
