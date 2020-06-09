using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class EgyptianInteractionFactory : InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (i == 0)
            {
                i++;
                EgyptianInteractions.SethEncounter seth = new EgyptianInteractions.SethEncounter(parentSession);
                EgyptianInteractions.OsirisEncounter osiris = new EgyptianInteractions.OsirisEncounter(parentSession);
                EgyptianInteractions.RaaEncounter raa = new EgyptianInteractions.RaaEncounter(parentSession);
                EgyptianInteractions.HorusEncounter horus = new EgyptianInteractions.HorusEncounter(parentSession);
                EgyptianInteractions.SphinxEncounter sphinx = new EgyptianInteractions.SphinxEncounter(parentSession, osiris, raa, horus);
                return new List<Interaction>() { seth, sphinx, osiris, raa, horus };
            }
            else return new List<Interaction>();
        }
    }
}
