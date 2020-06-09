using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    interface IMysticStrategy 
    {
        void Talk(GameSession ses, Mystic mystic);

    }
}
