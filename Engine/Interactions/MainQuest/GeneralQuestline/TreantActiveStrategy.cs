using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine;
using Game.Engine.Items.BasicArmor;
using Game.Engine.Monsters.Built_In;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class TreantActiveStrategy : ITreantStrategy
    {
        public bool Execute(GameSession parentSession, bool complete)
        {
            parentSession.SendText("*The trees, bushes and tall grass are blocking the path*");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "*cut through grass and go forward*", "*turn back*" });
            if (choice == 1) return false;
            parentSession.SendText("*There is a giant tree in quite an unusual spot, blocking the path*");
            int choice2 = parentSession.GetListBoxChoice(new List<string>() { "*try to get past it*", "*turn back*" });
            if (choice2 == 1) return false;
            parentSession.SendText("The tree just moved! It's a treant!");
            parentSession.GetListBoxChoice(new List<string>() { "*fight the treant*" });
            if(parentSession.TestForItem("item0420"))
            {
                parentSession.FightThisMonster(new TreantWeak());
            }
            else
            {
                parentSession.FightThisMonster(new TreantStrong());
            }
            parentSession.RemoveCurrentlyVisitedInteraction();
            return true;

        }
    }
}
