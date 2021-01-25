using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TempleGates
{
    [Serializable]
    class GatesFourthQuestionState : GatesState
    {
        public override void RunContent(GameSession parentSession, GatesEncounter myself, MainDarkElf.MainDarkElfEncounter elf, MainWitch.MainWitchEncounter witch, GeneralQuestline.LibrarianEncounter librarian)
        {
            parentSession.SendText("WHAT IS THE NAME OF OUR KING");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Kulu", "Mulu", "Nuku", "Kaan", "LEAVE" }); switch (choice)
            {
                case 3:
                    parentSession.SendText("CORRECT, WELCOME MY BROTHER");
                    parentSession.RemoveCurrentlyVisitedInteraction();
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
