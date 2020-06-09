using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.EchionNoiche
{
    [Serializable]
    class TempleEncounter : ConsoleInteraction
    {
        private bool visited = false;
        public ITempleStrategy Strategy { get; set; }
        public TempleEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1282";
            Strategy = new TempleNeutralStrategy();
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession, visited);
            visited = true;
        }
    }
}
