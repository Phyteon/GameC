using System;
using System.Collections.Generic;
using Game.Engine.Interactions.TrollBrothers;

namespace Game.Engine.Interactions.InteractionFactories
{ 
    [Serializable]
    class CymirCaveFactory : InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (i == 0)
            {
                i++;
                CaveEncounter cave = new CaveEncounter(parentSession);
                CymirEncounter cymir = new CymirEncounter(parentSession, cave);
                return new List<Interaction>() { cave, cymir };
            }
            else return new List<Interaction>();
        }
    }
}
