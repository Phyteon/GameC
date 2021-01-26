using Game.Engine.Interactions.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // meet with a troll named Hymir, who is a brother of Gymir
    // Hymir's behavior will depend on your previous interactions with Gymir, if you had them

    [Serializable]


     // store reference to Hymir
    class RedObeliskEncounter : PlayerInteraction
    {
        private StewardEncounter myself;
        private List<string> myColors;
        public IObeliskStrategy Strategy { get; set; } // store strategy 
        public RedObeliskEncounter(GameSession ses, List<string> myColors, StewardEncounter myself) : base(ses)
        {
            Name = "interaction0034";
            Strategy = new RedObeliskNeutral(); // start with default strategy
            this.myself = myself;
            this.myColors = myColors;
            this.parentSession = ses;
            Enterable = false;
        }
        protected override void RunContent()
        {
            myColors = Strategy.Execute(parentSession, Complete, myself, myColors); // execute strategy and check if we reached the end of this interaction
        }
    }
}
