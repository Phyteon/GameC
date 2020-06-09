using System;
using System.Collections.Generic;
using Game.Engine.Interactions.TroubadourQuest;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories

{
    [Serializable]
    class TroubadourFactory : InteractionFactory
    {
        private int used = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            if(used == 0)
            {
                used++;
                return new List<Interaction>() { new Troubadour(ses), new VillageInFlames(ses) };
            }
            else return new List<Interaction>();
        }
    }
}
