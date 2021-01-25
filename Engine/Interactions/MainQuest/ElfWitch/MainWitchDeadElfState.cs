using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainWitch
{
    [Serializable]
    class MainWitchDeadElfState : MainWitchState
    {
        public override void RunContent(GameSession parentSession, MainWitchEncounter myself, MainDarkElf.MainDarkElfEncounter mElf, List<BasicWitch.BasicWitchEncounter> bWitches)
        {
            parentSession.GetListBoxChoice(new List<string>() { "Could you tell me who this temple belongs to?" });
            parentSession.SendText("\nOf course I will tell you. I saw what you did to this witch. The Temple was built to worship the Spirit of the Moon");
            myself.ChangeState(new MainWitchGratefulState());
        }
    }
}
