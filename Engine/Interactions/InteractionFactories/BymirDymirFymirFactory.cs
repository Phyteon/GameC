using System;
using System.Collections.Generic;
using Game.Engine.Interactions.TrollBrothers;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class BymirDymirFymirFactory : InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (i == 0)
            {
                i++;
                FymirEncounter fymir = new FymirEncounter(parentSession);
                DymirEncounter dymir = new DymirEncounter(parentSession);
                BymirEncounter bymir = new BymirEncounter(parentSession);
                return new List<Interaction>() { fymir, bymir, dymir };
            }
            else return new List<Interaction>();
        }
    }
}
