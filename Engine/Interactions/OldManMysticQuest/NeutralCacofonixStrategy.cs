using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    [Serializable]
    class NeutralCacofonixStrategy : ICacofonixStrategy
    {
        public void ExecuteCacof(GameSession parentSession, bool visited)
        {
            parentSession.SendText("Hello there stranger! My name is Cacofonix, do you want to listen to one of my songs?");
        }
    }
}
