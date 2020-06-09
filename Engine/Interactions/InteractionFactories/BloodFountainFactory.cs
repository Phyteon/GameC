using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class BloodFountainFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession ses)
        {
            return new List<Interaction>() { new Misc.BloodFountainInteraction(ses) };
        }
    }
}
