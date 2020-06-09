using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    interface INoicheStrategy
    {
        void Execute(GameSession ses, bool visited);
    }
}
