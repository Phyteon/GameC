using System;
using System.Collections.Generic;
using Game.Engine.Interactions.LootingLute;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class LootingLuteFactory:InteractionFactories.InteractionFactory
    {
        private int used = 0;
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            if (used == 0)
            {
                used++;
                CaveEncounter cave = new CaveEncounter(parentSession);
                SewersEncounter sewers = new SewersEncounter(parentSession, cave);
                StudentHouseEncounter student = new StudentHouseEncounter(parentSession, sewers);
                TavernEncounter tavern = new TavernEncounter(parentSession, student);
                return new List<Interaction>() { cave, sewers, student, tavern };
            }
            else return new List<Interaction>();

        }

    }
}
