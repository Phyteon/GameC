using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Interactions.Houndmaster;

namespace Game.Engine.Interactions.InteractionFactories
{
    class HoundmasterFactory : InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (i == 0)
            {
                i++;
                IceHoundEncounter iceHound = new IceHoundEncounter(parentSession);
                FireHoundEncounter fireHound = new FireHoundEncounter(parentSession);
                ShadowHoundEncounter shadowHound = new ShadowHoundEncounter(parentSession);
                HoundmasterEncounter houndmaster = new HoundmasterEncounter(parentSession, iceHound, fireHound, shadowHound);
                return new List<Interaction>() { houndmaster };
            }
            else return new List<Interaction>();
        }
    }
}
