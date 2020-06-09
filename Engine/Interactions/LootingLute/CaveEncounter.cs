using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.LootingLute
{
    [Serializable]
    class CaveEncounter:ImageInteraction
    {
        
        public ICaveStrategy strategy;
        public int tavernHelper = 0;
        public CaveEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0623";
            strategy = new CaveNeutralStrategy();
            
            if(strategy == new CaveFriendlyStrategy())
            {
                displayedImageName = "interaction0623_2display";
            }
            else if(strategy == new CaveHostileStrategy())
            {
                displayedImageName = "interaction0623_1display";
            }
            else
            {
                displayedImageName = "interaction0623display";
            }
        }
        protected override void RunContent()
        {
            strategy.Execute(parentSession);
            
        }
    }
}
