using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class StewardHostileState : StewardState
    {
        public override void RunContent(GameSession parentSession, StewardEncounter myself, GateEncounter gate)
        {
            parentSession.SendText("Go away!");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Go away", "Try to pay him (100 gold)" });
            switch (choice)
            {
                case 0:
                break;
                case 1:
                pay(parentSession, myself);
                break;
            }
            return;
        }

        private void pay(GameSession parentSession, StewardEncounter myself)
        {
            parentSession.UpdateStat(8, -100);
            parentSession.SendText("\nHymm, golem... I think you have to find the tower of the necromancer.");
            //parentSession.SendText("\nEhh... I remember some old books in the catacombs.");
            //parentSession.SendText("You have to find secret passage with a hidden portal to get it");
            //parentSession.SendText("Good luck! Visit me once you get it");
            myself.ChangeState(new StewardWaitingState());
        }
    }
}
