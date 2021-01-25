using Game.Engine.Interactions.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class LibrarianEncounter : PlayerInteraction
    {
        private LibrarianState currentState;
        private TreantEncounter treant;
        public LibrarianEncounter(GameSession ses, TreantEncounter treant) : base(ses)
        {
            Enterable = false;
            parentSession = ses;
            Name = "interaction0013";
            currentState = new LibrarianDefaultState();
            this.treant = treant;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, treant);
        }
        public void ChangeState(LibrarianState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true;
        }
    }
}
