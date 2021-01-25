using Game.Engine.Interactions.GeneralQuestline;
using Game.Engine.Interactions.Shrines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class ShrineFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            int shrineType = Index.RNG(0, 6);
            switch(shrineType)
            {
                case 0:
                    return new List<Interaction>() { new RandomShrine(parentSession)};
                case 1:
                    return new List<Interaction>() { new BattleShrine(parentSession) };
                case 2:
                    return new List<Interaction>() { new BerserkerShrine(parentSession) };
                case 3:
                    return new List<Interaction>() { new CatShrine(parentSession) };
                case 4:
                    return new List<Interaction>() { new ElephantShrine(parentSession) };
                case 5:
                    return new List<Interaction>() { new HunterShrine(parentSession) };
            }
            return new List<Interaction>();
        }
    }
}
