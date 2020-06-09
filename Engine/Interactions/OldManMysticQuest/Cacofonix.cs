using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    [Serializable]
    class Cacofonix : ConsoleInteraction
    {
        public ICacofonixStrategy Strategy { get; set; }
        private bool visited = false;
        public Cacofonix(GameSession ses) : base(ses) //start with neutral strategy which will change later
        {
            Name = "interaction0349";
            Strategy = new NeutralCacofonixStrategy();
        }
        protected override void RunContent()
        {
            Strategy.ExecuteCacof(parentSession, visited); 
            visited = true;
        }
    }
}
