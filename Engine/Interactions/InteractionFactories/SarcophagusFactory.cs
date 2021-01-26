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
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            if (i < 10)
            {
                i++;
                return new List<Interaction>() { new SarcophagusInteraction(ses) };
            }
            else return new List<Interaction>();
        }
        
    }
}
