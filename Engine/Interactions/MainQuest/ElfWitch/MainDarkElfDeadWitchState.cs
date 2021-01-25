using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.MainDarkElf
{
    class MainDarkElfDeadWitchState : MainDarkElfState
    {
        public override void RunContent(GameSession parentSession, MainDarkElfEncounter myself, MainWitch.MainWitchEncounter mWitch, List<BasicDarkElf.BasicDarkElfEncounter> bElfs)
        {
            parentSession.GetListBoxChoice(new List<string>() { "Could you tell what was the main rule of fairies?" });
            parentSession.SendText("\nOf course I will tell you. I saw what you did to this witch. They main rule was PRAY TO THE FULL MOON");
            myself.ChangeState(new MainDarkElfGratefulState());
        }
    }
}
