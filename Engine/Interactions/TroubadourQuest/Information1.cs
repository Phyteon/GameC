using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TroubadourQuest
{
	[Serializable]
    class Information1 : ImageInteraction
    {
        public Information1(GameSession ses) : base(ses)
        {
            Name = "interaction0542";
            displayedImageName = "interaction0542display";
        }

        protected override void RunContent()
        {
            parentSession.GetValidKeyResponse(new List<string>{ "Space"});//skip with space

        }
    }
}

