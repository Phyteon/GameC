using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;

namespace Game.Engine.Interactions.Wolf
{
    [Serializable]
    class WolfInteractionState : WolfState
    {

        public override void RunContent(GameSession parentSession, List<BasicWitch.BasicWitchEncounter> bWitches, MainWitch.MainWitchEncounter mWitch)
        {
            parentSession.SendText("\nGrrr...");
            parentSession.FightThisMonster(new Monsters.Forest.Wolf(), false);
            parentSession.SendText("\n You can now bring animal alive or kill it.");
            int choice = parentSession.GetListBoxChoice(new List<string>() { "Kill anmial (new hat)", "Bring alive (new companion)" });
            switch (choice)
            {
                case 0:
                    parentSession.SendText("\n You gain Wolf Hat");
                    // parentSession.AddThisItem(bearfHat); // wolf hat item
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0124"));
                    parentSession.RemoveCurrentlyVisitedInteraction();
                    break;
                case 1:
                    parentSession.SendText("\n Get back to Bulgur.");
                    parentSession.AddThisItem(Index.ProduceSpecificItem("item0134")); // wolf with blood, png with name, no stats
                    parentSession.RemoveCurrentlyVisitedInteraction();
                    break;
            }

        }
    }
}
