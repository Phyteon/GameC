using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // a special interaction used for healing 
    // if you want a clear example of how to write your own interesting interaction, this is probably NOT the right place 
    // see Gymir and Hymir files instead

    [Serializable]
    class GateOpenState : GateState
    {
        public override void RunContent(GameSession sys, GateEncounter myself)
        {
           
        }
    }
}
