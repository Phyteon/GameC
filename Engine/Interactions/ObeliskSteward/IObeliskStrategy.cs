using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    interface IObeliskStrategy
    {
        List<string> Execute(GameSession ses, bool Complete, StewardEncounter myself, List<string> list);

        List<string> Order(GameSession ses, StewardEncounter myself, List<string> list);
    }
}
