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
     * Basic Training - kind of a tutorial for the game, as well as random class weapon drop.
    */

    [Serializable]
    class TrainingEncounter : PlayerInteraction
    {
        private TrainingState currentState; // current state of this interaction (design pattern)
        public TrainingEncounter(GameSession ses) : base(ses)
        {
            parentSession = ses;
            Name = "interaction0011";
            Enterable = false;
            currentState = new TrainingInitialState();
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this);
        }
        public void ChangeState(TrainingState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }
    }
}