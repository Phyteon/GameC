using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Druid
{
    [Serializable]
    abstract class DruidState
    {
        public abstract void RunContent(GameSession ses, DruidEncounter myself, Wolf.WolfEncounter myWolf, Bear.BearEncounter myBear, Fox.FoxEncounter myFox, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch);
    }
}
