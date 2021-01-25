using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.TempleGates
{
    [Serializable]
    class GatesEncounter : PlayerInteraction
    {
        private GatesState currentState; // current state of this interaction (design pattern)
        public MainWitch.MainWitchEncounter witch; // witches
        public MainDarkElf.MainDarkElfEncounter elf; // dark elves
        public GeneralQuestline.LibrarianEncounter librarian;
        //public Fox.FoxEncounter myFox;  // librarian

        public GatesEncounter(GameSession ses, MainDarkElf.MainDarkElfEncounter elf, MainWitch.MainWitchEncounter witch, GeneralQuestline.LibrarianEncounter librarian) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0027";
            currentState = new GatesFirstQuestionState();
            this.witch = witch;
            this.elf = elf;
            this.librarian = librarian;
            Enterable = false;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, elf, witch, librarian);
        }
        public void ChangeState(GatesState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }
    }
}
