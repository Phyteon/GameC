using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TroubadourQuest
{
	[Serializable]
    class Information2:InteractionWithImage
    {
        public Information2(GameSession ses) : base(ses)
        {
            Name = "interaction0543";
            displayedImageName = "interaction0543display";
        }

        protected override void RunContent()
        {
            parentSession.GetValidKeyResponse(new List<string>() { "Space"});//skip with space
        }
    }
}

