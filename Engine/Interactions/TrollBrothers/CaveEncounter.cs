using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TrollBrothers
{
    [Serializable]
    class CaveEncounter : ConsoleInteraction
    {
        private bool visited = false;
        public ICave Strategy { get; set; }
        public CaveEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction1144";
            Strategy = new CaveNormalStrategy();
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession, visited);
            visited = true;
        }
    }
}
