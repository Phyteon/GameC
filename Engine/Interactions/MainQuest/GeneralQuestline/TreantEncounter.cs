using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class TreantEncounter : PlayerInteraction
    {
        public ITreantStrategy Strategy { get; set; } // store strategy 
        public TreantEncounter(GameSession ses) : base(ses)
        {
            Enterable = false;
            Name = "interaction0014";
            Strategy = new TreantInitialStrategy(); // start with default strategy
        }
        protected override void RunContent()
        {
            Complete = Strategy.Execute(parentSession, Complete); // execute strategy and check if we reached the end of this interaction
        }
    }
}
