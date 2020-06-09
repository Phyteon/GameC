using Game.Engine.Interactions.EchionNoiche;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class EchionNoicheFactory : InteractionFactory
    {
        private int used = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if(used == 0)
            {
                used++;
                NoicheEncounter noiche = new NoicheEncounter(parentSession);
                TempleEncounter temple = new TempleEncounter(parentSession);
                EchionEncounter echion = new EchionEncounter(parentSession, noiche, temple);
                DragonFireEncounter dragonFire = new DragonFireEncounter(parentSession, echion, noiche, temple);
                return new List<Interaction>() { noiche, echion, temple, dragonFire };
            }
            else return new List<Interaction>();
        }
    }
}
