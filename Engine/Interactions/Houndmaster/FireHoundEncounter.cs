using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.Houndmaster
{
    class FireHoundEncounter : PlayerInteraction
    {
        public FireHoundEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0202";
        }
        protected override void RunContent()
        {
            parentSession.SendText("\nYou have found one of the missing hounds");
            int decision = parentSession.GetListBoxChoice(new List<string>() { "*try to capture it*", "leave it alone" });
            if (decision == 1) return;
            parentSession.FightThisMonster(new FireHound());
            parentSession.SendText("\nYou have captured the Fire Hound");
            parentSession.RemoveCurrentlyVisitedInteraction();
            Complete = true;
        }
    }
}
