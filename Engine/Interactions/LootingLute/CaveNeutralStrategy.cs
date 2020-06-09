using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.LootingLute
{
    [Serializable]
    class CaveNeutralStrategy: ICaveStrategy
    {
        public void Execute(GameSession parentSession)
        {
            parentSession.SendText("\nYou find a cave, but it's empty and trully boring");
            return;
            
        }
    }
}
