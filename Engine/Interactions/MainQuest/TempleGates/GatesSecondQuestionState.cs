using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TempleGates
{
    [Serializable]
    class GatesSecondQuestionState : GatesState
    {
        public override void RunContent(GameSession parentSession, GatesEncounter myself, MainDarkElf.MainDarkElfEncounter elf, MainWitch.MainWitchEncounter witch, GeneralQuestline.LibrarianEncounter librarian)
        {
            parentSession.SendText("WHOSE THIS TEMPLE BELONGS TO");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Sun", "Moon", "Death", "Wind", "LEAVE" });
            switch (choice)
            {
                case 1:
                    parentSession.SendText("CORRECT");
                    myself.ChangeState(new GatesThirdQuestionState(), false);
                    elf.ChangeState(new MainDarkElf.MainDarkElfInitialState());
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
