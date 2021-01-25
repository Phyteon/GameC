using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TempleGates
{
    [Serializable]
    class GatesThirdQuestionState : GatesState
    {
        public override void RunContent(GameSession parentSession, GatesEncounter myself, MainDarkElf.MainDarkElfEncounter elf, MainWitch.MainWitchEncounter witch, GeneralQuestline.LibrarianEncounter librarian)
        {
            parentSession.SendText("WHAT IS OUR MAIN RULE");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Pray to the full moon.", "Pray to the sun.", "Go to the temple barefoot.", "Wash your hands for 30 seconds.", "LEAVE" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("CORRECT");
                    myself.ChangeState(new GatesFourthQuestionState(), false);
                    librarian.ChangeState(new GeneralQuestline.LibrarianGatesState());
                    break;
                case 3:
                    parentSession.SendText("CORRECT BUT IN REAL LIFE");
                    break;

                case 4:
                    break;
                default:
                    parentSession.SendText("WRONG");
                    parentSession.FightRandomMonster(); // drzwi, które zadają obrażenia i umierają.
                    break;
            }
        }
    }
}
