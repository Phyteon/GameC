using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.Houndmaster
{
    class ShadowHoundEncounter : PlayerInteraction
    {
        public ShadowHoundEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0203";
        }
        protected override void RunContent()
        {
            parentSession.SendText("\nYou have found one of the missing hounds");
            int decision = parentSession.GetListBoxChoice(new List<string>() { "*try to capture it*", "leave it alone" });
            if (decision == 1) return;
            parentSession.FightThisMonster(new ShadowHound());
            parentSession.SendText("\nYou have captured the Shadow Hound");
            parentSession.RemoveCurrentlyVisitedInteraction();
            Complete = true;
        }
    }
}
