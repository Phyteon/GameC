using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class OldTravelerFactory : InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            if (i == 0)
            {
                i++;
                return new List<Interaction>() { new OldTravelerEncounter(ses) };
            }
            else return new List<Interaction>();
        }
    }
}