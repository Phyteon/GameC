using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.LootingLute
{
    [Serializable]
    class CaveHostileStrategy: ICaveStrategy
    {
        bool visited = false;
        public void Execute(GameSession parentSession)
        {
            if(visited)
            {
                parentSession.SendText("Haven't you learned your lesson?!");
                parentSession.FightRandomMonster();
            }
            else
            {
                parentSession.SendText("Ohh, it's you! I know that you betrayed me... Did he paid well for my head? As you can see, I'm alive and have new friend. And now, you'll be defeated by Dante Lion and his new comrade!");
                parentSession.FightRandomMonster();
                visited = true;
            }
        }
    }
}
