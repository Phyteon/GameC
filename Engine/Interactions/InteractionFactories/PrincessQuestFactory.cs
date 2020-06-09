using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Interactions.PrincessQuest;
using Game.Display;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class PrincessQuestFactory :InteractionFactory
    {
        private int ifCreated = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if(ifCreated == 0)
            {
                TowerEncounter tower = new TowerEncounter(parentSession);
                MageEncounter mage = new MageEncounter(parentSession, tower);
                KingEncounter king = new KingEncounter(parentSession, mage, tower);
                RingCreatureEncounter ring = new RingCreatureEncounter(parentSession, king);
                SmithEncounter smith = new SmithEncounter(parentSession, king, ring);
                ifCreated = 1;
                return new List<Interaction>() { tower, mage, king, ring, smith };
            }
            return new List<Interaction>() { };
        }
    }
}
