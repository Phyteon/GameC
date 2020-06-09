using Game.Engine.Interactions.Muses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class MusesFactory: InteractionFactory
    {
        private int i = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (i == 0)
            {
                ApolloEncounter apollo = new ApolloEncounter(parentSession);
                EuterpeEncounter euterpe = new EuterpeEncounter(parentSession, apollo);
                EratoEncounter erato = new EratoEncounter(parentSession, apollo, euterpe);
                TerpsichoreEncounter terpsichore = new TerpsichoreEncounter(parentSession, apollo, erato);
                PolyhymniaEncounter polyhymnia = new PolyhymniaEncounter(parentSession, apollo, erato, euterpe, terpsichore);
                i++;
                return new List<Interaction>() { apollo, euterpe, erato, terpsichore, polyhymnia };
            }
            else
                return new List<Interaction>();
        }
    }
}
