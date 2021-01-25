using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.GeneralQuestline
{
    [Serializable]
    class CampEncounter : PlayerInteraction
    {
        private CampState currentState;
        public bool Decision { get; private set; } //true for telling truth, false for telling lie
        public CampEncounter(GameSession ses) : base(ses)
        {
            //enterable
            parentSession = ses;
            Name = "interaction0012";
            currentState = new CampInitialState();
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this);
        }
        public void ChangeState(CampState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true;
        }
        public void ChooseDecision(bool choice)
        {
            Decision = choice;
        }
    }
}
