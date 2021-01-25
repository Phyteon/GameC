using Game.Engine.Interactions.Built_In;
using Game.Engine.Interactions.GeneralQuestline;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions
{
    /*
     * General, the first NPC in the game. 
    */

    [Serializable]
    class GeneralEncounter : PlayerInteraction
    {
        private GeneralState currentState; // current state of this interaction (design pattern)
        private TrainingEncounter training;
        private CampEncounter camp;
        private LibrarianEncounter librarian;
        private TreantEncounter treant;
        public GeneralEncounter(GameSession ses, TrainingEncounter training, CampEncounter camp, LibrarianEncounter librarian, TreantEncounter treant) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0010";
            Enterable = false;
            currentState = new GeneralInitialState();
            this.training = training;
            this.camp = camp;
            this.librarian = librarian;
            this.treant = treant;
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, training, camp, librarian, treant);
        }
        public void ChangeState(GeneralState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }
    }
}