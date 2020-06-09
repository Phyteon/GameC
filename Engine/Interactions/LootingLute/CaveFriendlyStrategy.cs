using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.LootingLute
{
    [Serializable]
    class CaveFriendlyStrategy : ICaveStrategy
    {
        bool visited = false;
        public void Execute(GameSession parentSession)
        {
            if (visited)
            {
                parentSession.SendText("\nHello my friend! Nice to meet you again!");
                return;
            }
            else
            {
                parentSession.SendText("\nHello my friend! We meet again! I haven't forgotten what you did for me. Here, take this, I've promised you a reward. I know your homeland and I know why are you on your adventure. Remember not to trust anyone, even me! Hahaha!");
                parentSession.AddRandomClassItem();
                parentSession.UpdateStat(7, 500);
                visited = true;
                
            }
        }
    }
}
