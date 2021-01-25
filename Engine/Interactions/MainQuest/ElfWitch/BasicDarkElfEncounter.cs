using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.BasicDarkElf
{
    [Serializable]
    class BasicDarkElfEncounter : PlayerInteraction
    {
        public IBasicDarkElfStrategy Strategy { get; set; } // store strategy 
        public BasicDarkElfEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction00025";
            Strategy = new BasicDarkElfNeutralStrategy(); // start with default strategy
            Enterable = false;
        }
        protected override void RunContent()
        {
            Complete = Strategy.Execute(parentSession, Complete); // execute strategy and check if we reached the end of this interaction
        }
    }
}
