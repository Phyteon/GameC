using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    interface ICacofonixStrategy
    {
        void ExecuteCacof(GameSession ses, bool visited);
    }
}
