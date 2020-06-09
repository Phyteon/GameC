using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EgyptianInteractions
{
    public interface ICommand
    {
        void Execute(GameSession parentSession);

    }
}
