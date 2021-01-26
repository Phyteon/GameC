using Game.Engine.Items;
using Game.Engine.Items.Built_In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.Necromancer
{
    [Serializable]
    class NecromancerEncounter : PlayerInteraction
    {
        
        private NecromancerState currentState; // current state of this interaction (design pattern)
        private LichEncounter catacombsLich; // store reference to Lich  
        public CatacombsKey Key = new CatacombsKey();
        public LichsStaff Staff = new LichsStaff();
        public bool QuestStarted = false;
        public NecromancerEncounter(GameSession ses) : base(ses)
        {

            parentSession = ses;
            Name = "interaction0150";
            currentState = new NecromancerInitialState();
        }

        public void SetLich(LichEncounter catacombsLich)
        {
            // this isn't how it should work, but for now let's just help it run - JCH
            this.catacombsLich = catacombsLich; // set reference to Lich
        }
        protected override void RunContent()
        {
            if (catacombsLich.Complete == true) currentState = new NecromancerQuestMidState();
            currentState.RunContent(parentSession, this, catacombsLich);
        }
        public void ChangeState(NecromancerState newState, bool isCompleted = false)
        {
            currentState = newState;
            if (isCompleted) Complete = true; // while changing state, we may also want to set this property
        }
    }
}

