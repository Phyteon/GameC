using Game.Engine.Interactions.MageQuest;
using System;
using System.Collections.Generic;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class MageQuestFactory:InteractionFactory
    {

        private int limit=0;
        private HelpfulMage privMage;
       
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (limit == 0)
            {
                HelpfulMage mage = new HelpfulMage(parentSession);
                privMage = mage;
                FriendlyWarrior warrior = new FriendlyWarrior(parentSession);
                Smith smith = new Smith(parentSession, mage);
                FriendlyMage friendlyMage = new FriendlyMage(parentSession, mage, warrior);
                SpiderCave cave1 = new SpiderCave(parentSession, mage);
                PhoenixNest nest1 = new PhoenixNest(parentSession, mage);
                Sanctuary sanctuary1 = new Sanctuary(parentSession, mage);
                limit = +1;
                return new List<Interaction>() { mage, warrior, smith, friendlyMage, cave1, nest1, sanctuary1 };
            }
            else
            {
                SpiderCave cave2 = new SpiderCave(parentSession, privMage);
                PhoenixNest nest2 = new PhoenixNest(parentSession, privMage);
                Sanctuary sanctuary2 = new Sanctuary(parentSession, privMage);
                return new List<Interaction>() { cave2, nest2, sanctuary2};
            }
            
        }

    }
}
