using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Interactions.GuitarQuest;

namespace Game.Engine.Interactions.InteractionFactories
{
    class GuitarQuestFactory:InteractionFactory
    {
        private bool wasQuestlineProduced;
        public GuitarQuestFactory()
        {
            wasQuestlineProduced = false;
        }
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            //it's a questline, only one of those can exist in the game world
            if (!wasQuestlineProduced)
            {
                LeonardoInteraction leonardo = new LeonardoInteraction(parentSession);
                AdvelarInteraction advelar = new AdvelarInteraction(parentSession, leonardo);
                BeggarInteraction anielka = new BeggarInteraction(parentSession, leonardo);
                StringOnGroundInteraction stringOnGround = new StringOnGroundInteraction(parentSession, leonardo);
                KellanInteraction kellan = new KellanInteraction(parentSession, leonardo);
                MellanInteraction mellan = new MellanInteraction(parentSession, leonardo, kellan);
                kellan.mellanMyFriend = mellan;
                wasQuestlineProduced = true;
                return new List<Interaction>() { leonardo, advelar, anielka, stringOnGround, kellan, mellan };
            }
            else
            {
                return null;
            }
           
        }
    }
}
