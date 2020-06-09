using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class TempleHostileStrategy2 : ITempleStrategy
    {
        public void Execute(GameSession parentSession, bool visited)
        {
            if (visited)
            {
                parentSession.SendText("\n*You witness how an enourmus fire in the shape of dragon flies through the skies.*");
                parentSession.SendText("\n*It seem like he is surrounded by smaller sentient flames. Mayby its weird, but you feel that they are... happy.*");
                parentSession.SendText("\n*And the world is definitely doomed.*");
                return;
            }
            else
            {
                parentSession.SendText("\n*As you approaching the temple, you feel that the ground is shaking.*");
                parentSession.SendText("\n*You witness how an enourmus fire in the shape of dragon erupts from the building.*");
                parentSession.SendText("\n*It seem like he is surrounded by smaller sentient flames. Mayby its weird, but you feel that they are... happy.*");
                parentSession.SendText("\n*And the world is probably doomed.*");
                return;
            }
        }
    }
}
