using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TempleGates
{
    [Serializable]
    class GatesFirstQuestionState : GatesState
    {
        public override void RunContent(GameSession parentSession, GatesEncounter myself, MainDarkElf.MainDarkElfEncounter elf, MainWitch.MainWitchEncounter witch, GeneralQuestline.LibrarianEncounter librarian)
        {
            parentSession.SendText("TO ENTER THIS TEMPLE YOU HAVE TO ANSWER FOUR QUESTIONS. \n EACH WRONG ANSWER WILL BE REWARDED WITH PAIN.");
            parentSession.SendText("\n FIRST QUESTION \n WHO BUILT THIS TEMPLE?");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Fairies", "Humans", "Witches", "Dark Elves", "LEAVE" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("CORRECT");
                    myself.ChangeState(new GatesSecondQuestionState(), false);
                    witch.ChangeState(new MainWitch.MainWitchInitialState());
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
