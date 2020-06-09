using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EgyptianInteractions
{
    [Serializable]
    class DeathCommand : ICommand
    {
        IGod god;
        public DeathCommand(IGod god)
        {
            this.god = god;
        }

        public void Execute(GameSession parentSession)
        {
            god.Die(parentSession);
        }
    }
}
