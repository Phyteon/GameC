using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Amulet
{
    [Serializable]
    class AmuletInitialState : AmuletState
    {
        public override void RunContent(GameSession parentSession)
        {
            parentSession.AddThisItem(Index.ProduceSpecificItem("item0131"));
            parentSession.RemoveCurrentlyVisitedInteraction();
        }
    }
}
