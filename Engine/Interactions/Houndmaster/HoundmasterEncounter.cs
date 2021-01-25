using Game.Engine.Interactions.Built_In;
using Game.Engine.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Houndmaster
{
    // meet with an old troll named Gymir
    // Gymir has also a brother - Hymir

    [Serializable]
    class HoundmasterEncounter : PlayerInteraction
    {
        private HoundmasterState currentState;
        private IceHoundEncounter iceHound;
        private FireHoundEncounter fireHound;
        private ShadowHoundEncounter shadowHound;
        public HoundmasterEncounter(GameSession ses, IceHoundEncounter iceHound, FireHoundEncounter fireHound, ShadowHoundEncounter shadowHound) : base(ses)
        {
            Enterable = false;
            parentSession = ses;
            Name = "interaction0200";
            this.iceHound = iceHound;
            this.fireHound = fireHound;
            this.shadowHound = shadowHound;
            currentState = new HoundmasterInitialState();
        }
        protected override void RunContent()
        {
            currentState.RunContent(parentSession, this, iceHound, fireHound, shadowHound);
        }
        public void ChangeState(HoundmasterState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }
    }
}
