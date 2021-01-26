using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Built_In
{
    [Serializable]
    class StewadrNeutralState : StewardState
    {
        public override void RunContent(GameSession parentSession, StewardEncounter myself, GateEncounter gate)
        {
            CloseTheGate(gate);
            parentSession.SendText("\nWho you are? Why are you disturbing me from the study of my books?");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "The general sends me", "You have to tell me what you know about the golem, or I'll kill you (attack)" });
            switch (choice)
            {
                case 0:
                parentSession.SendText("\nWhat he want?");
                int choice2 = parentSession.GetListBoxChoice(new List<string>() { "I need to find out some information about the golem" });
                switch (choice)
                {
                    case 0:
                    parentSession.SendText("\nIt will cost");
                    int choice3 = parentSession.GetListBoxChoice(new List<string>() {"Go away", "Pay him (50gold)" });
                    switch (choice3)
                    {
                        case 0:                        
                        break;
                        case 1:
                        pay(parentSession, myself);
                        break;
                    }
                    break;
                }
                break;
                case 1:
                Attacked(myself, parentSession);
                break;
            }
           
        }
        private void CloseTheGate(GateEncounter gate)
        {
            gate.ChangeState(new GateClosedState());
        }

        private void Attacked(StewardEncounter myself, GameSession parentSession)
        {
            //parentSession.SendText("abrakadabra");
            //parentSession.SendText("\nUou see a blinding light. Steward curses you");
            parentSession.FightRandomMonster();
            myself.ChangeState(new StewardHostileState());
        }

        private void pay(GameSession parentSession, StewardEncounter myself)
        {
            parentSession.UpdateStat(8, -50);
            parentSession.SendText("\nHymm, golem... I think you have to find the tower of the necromancer.");
            //parentSession.SendText("\nHymm, golem... I remember some old books in the catacombs.");
            //parentSession.SendText("You have to find secret passage with a hidden portal to get it");
            //parentSession.SendText("Good luck! Visit me once you get it");
            myself.ChangeState(new StewardWaitingState());
        }


    }
}
