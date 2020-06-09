using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.PrincessQuest
{
    interface IMageStrategy
    {
        void Execute(GameSession ses, int visited);
    }
}
