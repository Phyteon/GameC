using Game.Engine.Interactions.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.BasicWitch
{
    [Serializable]
    class BasicWitchEncounter : PlayerInteraction
    {
        //public MainWitch.MainWitchEncounter mWitch;
        public IBasicWitchStrategy Strategy { get; set; } // store strategy 
        public BasicWitchEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0023";
            Strategy = new BasicWitchNeutralStrategy(); // start with default strategy
            Enterable = false;

        }
        protected override void RunContent()
        {
            Complete = Strategy.Execute(parentSession, Complete); // execute strategy and check if we reached the end of this interaction
        }
    }
}
