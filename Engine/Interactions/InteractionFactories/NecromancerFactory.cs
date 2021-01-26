using Game.Engine.Interactions.Necromancer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class NecromancerFactory : InteractionFactory
    {
        
            private int i = 0;
            public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
            {
                if (i == 0)
                {
                    
                    i++;
                    
                    NecromancerEncounter necro = new NecromancerEncounter(parentSession);
                    LichEncounter lich = new LichEncounter(parentSession, necro);
                    necro.SetLich(lich);

                return new List<Interaction>() { necro, lich };
                }
                else return new List<Interaction>();
            }
    }
}

