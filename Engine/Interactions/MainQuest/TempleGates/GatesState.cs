using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TempleGates
{
    [Serializable]
    abstract class GatesState
    {
        public abstract void RunContent(GameSession ses, GatesEncounter myself, MainDarkElf.MainDarkElfEncounter elf, MainWitch.MainWitchEncounter witch, GeneralQuestline.LibrarianEncounter librarian);

    }
}
