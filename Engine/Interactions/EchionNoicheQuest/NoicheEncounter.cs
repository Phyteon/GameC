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
    class NoicheEncounter : ConsoleInteraction
    {
        private bool visited = false;
        public INoicheStrategy Strategy { get; set; }
        public NoicheEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1280";
            Strategy = new NoicheNeutralStrategy();
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession, visited);
            visited = true;
        }
    }
}
