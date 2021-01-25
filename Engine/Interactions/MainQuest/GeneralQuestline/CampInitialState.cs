using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class CampInitialState : CampState
    {
        public override void RunContent(GameSession parentSession, CampEncounter myself)
        {
            parentSession.SendText("\nHey, you are not supposed to be here. What do you want? ");
            parentSession.GetListBoxChoice(new List<string>() { "Sorry, I was just passing by"});
            parentSession.SendText("");
            return;
        }
    }
}
