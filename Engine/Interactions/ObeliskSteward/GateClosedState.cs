using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    // a special interaction used for healing 
    // if you want a clear example of how to write your own interesting interaction, this is probably NOT the right place 
    // see Gymir and Hymir files instead

    [Serializable]
    class GateClosedState : GateState
    {
        public override void RunContent(GameSession parentSession, GateEncounter myself)
        {
            parentSession.SendText("\nIt looks like they are closed");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Go away", "Try to hit", "Try to use a lockpick (1% opportunities)" });
            switch (choice)
            {
                case 0:
                break;
                case 1:
                parentSession.SendText("\nIt probably wasn't a good decision...");
                parentSession.FightRandomMonster();
                break;
                case 2:
                if (Index.RNG(0, 99) == 23) myself.ChangeState(new GateOpenState());
                break;
                default:
                break;
            }
        }
    }
}
