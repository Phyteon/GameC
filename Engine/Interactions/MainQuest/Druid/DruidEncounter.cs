using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Druid
{

        [Serializable]
        class DruidEncounter : PlayerInteraction
        {
            
            private DruidState currentState; // current state of this interaction (design pattern)
            public Wolf.WolfEncounter myWolf;
            public Bear.BearEncounter myBear;
            public Fox.FoxEncounter myFox;
            public List<BasicWitch.BasicWitchEncounter> bWitches;
            public MainWitch.MainWitchEncounter mWitch;
            public bool IsWolfChosen = false;
            public bool IsBearChosen = false;
            public bool IsFoxChosen = false;

        public DruidEncounter(GameSession ses, Wolf.WolfEncounter myWolf, Bear.BearEncounter myBear, Fox.FoxEncounter myFox, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch) : base(ses)
            {
                parentSession = ses;
                Name = "interaction0006";
                currentState = new DruidInitialState();
                this.myWolf = myWolf;
                this.myBear = myBear;
                this.myFox = myFox;
                this.bWitches = bWitches;
                this.mWitch = mWitch;
                Enterable = false;
            }
            protected override void RunContent()
            {
                currentState.RunContent(parentSession, this, myWolf, myBear, myFox, bWitches, mWitch);
            }
            public void ChangeState(DruidState newState, bool isCompleted = false)
            {
                currentState = newState;
                if (isCompleted) Complete = true; // while changing state, we may also want to set this property
            }
    }
}

