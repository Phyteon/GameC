using Game.Engine.Interactions.Built_In;
using Game.Engine.Interactions.Necromancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class SarcophagusFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            return new List<Interaction>() { new SarcophagusInteraction(ses) };
        }
        
    }
}
