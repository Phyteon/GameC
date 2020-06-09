using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Items;
using Game.Engine.Monsters;


namespace Game.Engine.Interactions.OldManMysticQuest
{
    [Serializable]
    class Boss3Encounter : ConsoleInteraction, IBoss
    {
                        
        public bool IsDefeated { get; set; }

        public string NameView { get; set; }
        public Item item { get; set; }
        public Boss3Encounter(GameSession ses) : base(ses)
        {
            Name = "interaction0343";
            
            IsDefeated = false;
            item = new AntiMagicHealthStone();
         }


        protected override void RunContent()
        {
            if(parentSession.TestForItem(item.Name) == true && IsDefeated == false) //if player have required item then he can fight
            {
                parentSession.SendText("Opening the doors..");
                parentSession.FightThisMonster(new FireDragon(parentSession.currentPlayer.Level));
                IsDefeated = true;
                parentSession.SendText("Congratulations! You won!");
            }
            else if(parentSession.TestForItem(item.Name) != true)
            {
                parentSession.SendText("You cannot fight this boss, required item needed...");
            }
            else
            {
                parentSession.SendText("You already beated this monster");
            }
        }
    }
}
