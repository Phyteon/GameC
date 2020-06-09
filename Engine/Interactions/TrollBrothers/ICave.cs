using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TrollBrothers
{
    interface ICave
    {
        void Execute(GameSession ses, bool visited);
    }
}
