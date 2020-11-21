using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Monsters;

namespace Game.Engine.Interactions.OldManMysticQuest
{
    [Serializable]
    class Treasury : PlayerInteraction
    {
        private OldMan oldMan;
        private Cacofonix cacofonix;
        public Treasury(GameSession ses, Cacofonix cacofonix, OldMan oldMan) : base(ses)
        {
            Name = "interaction0341";
            this.cacofonix = cacofonix;
            this.oldMan = oldMan;
        }
        protected override void RunContent()
        {
            if (oldMan.AllMissionCompleted) //if all missions are completed
            {
                parentSession.SendText("\nAfter all fights and long journey you finally made it to treasury...");
                parentSession.SendText("Old Man - HA! SUPRISE! I bet that you did not expect me to be here. I stoled the gift that you are looking for.");
                parentSession.SendText("Old Man - Now after these useless monsters died I can fully release my true power and rule the world! Now it`s time for you to DIE!");

                int choice = parentSession.GetListBoxChoice(new List<string>() { "I don`t want to fight with you, lets just talk.", "DIE OLD MAN!!11!1!" });
                switch (choice)
                {
                    case 0:
                        parentSession.SendText("Old Man - Shut up and fight like a man!");
                        parentSession.FightThisMonster(new OldManMonster(parentSession.currentPlayer.Level));
                        parentSession.SendText("Old Man - You have beaten me... but prepare for round two!");
                        parentSession.SendText("Weird looking man jumps from nowhere and knocks out the Old Man with a lute, that was probably Cacofonix... you have to find him");
                        cacofonix.Strategy = new FriendlyCacofonixStrategy();

                        break;

                    default:
                        parentSession.FightThisMonster(new OldManMonster(parentSession.currentPlayer.Level));
                        parentSession.SendText("Old Man - You won, but that is only a first round! ARGRGHH!!!");
                        parentSession.FightThisMonster(new RagedOldManMonster(parentSession.currentPlayer.Level));
                        parentSession.SendText("Old Man is defeated, but musicality gift have been stoled during your fight, probably Cacofonix did that... you have to find him");
                        cacofonix.Strategy = new UnfriendlyCacofonixStrategy();
                        break;
                }
            }
            else
            {
                parentSession.SendText("This treasury is locked...");
            }
        }
    }
}
