using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    abstract class Gymir
    {
        public abstract void RunContent(GameSession ses, GymirEncounter myself, HymirEncounter myBrother);
    }
}
