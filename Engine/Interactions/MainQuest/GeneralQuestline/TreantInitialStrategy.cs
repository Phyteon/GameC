using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class TreantInitialStrategy : ITreantStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("*There is nothing but trees and bushes*");
            parentSession.GetListBoxChoice(new List<string>() { "I should probably go back." });
            return false;
        }
    }
}
